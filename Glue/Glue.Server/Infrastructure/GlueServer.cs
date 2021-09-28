using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Glue.Common;
using Glue.Common.Extensions;
using Glue.Common.Helpers;
using Glue.Common.Infrastructure;
using Glue.Common.Models;
using Glue.Common.Models.Remote;
using Glue.Server.Models;
using Newtonsoft.Json;

namespace Glue.Server.Infrastructure
{
    public sealed class GlueServer
    {
        private readonly GlueServerOptions _options;

        public GlueServer(GlueServerOptions options)
        {
            _options = options;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            using HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add(_options.Endpoint);
            httpListener.Start();

            while (!cancellationToken.IsCancellationRequested)
            {
                HttpListenerContext context = await httpListener.GetContextAsync();

#pragma warning disable 4014
                // TODO: need to handle exceptions here too. 
                Task.Run(async () =>
                {
                    GlueCallResponse response;

                    try
                    {
                        object result = await HandleRequestAsync(context);

                        response = GlueCallResponseFactory.Create(true, result);
                    }
                    catch (GlueException glueException)
                    {
                        response = GlueCallResponseFactory.Create(glueException);
                    }

                    context.Response.ContentType = Constants.GlueContentType;

                    await using StreamWriter writer = new StreamWriter(context.Response.OutputStream);
                    await writer.WriteAsync(SerializationHelper.SerializeGlueCallResponse(response));
                }, cancellationToken);
#pragma warning restore 4014
            }
        }

        private async Task<object> HandleRequestAsync(HttpListenerContext context)
        {
            if (!string.Equals(context.Request.ContentType, Constants.GlueContentType,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new GlueException("Incorrect request content type", null);
            }

            string requestStr;
            using (StreamReader reader = new StreamReader(context.Request.InputStream))
            {
                requestStr = await reader.ReadToEndAsync();
            }

            GlueCall glueCall;
            try
            {
                glueCall = SerializationHelper.DeserializeGlueCall(requestStr);
            }
            catch (JsonException jsonException)
            {
                throw new GlueException("Failed to deserialize service call request", jsonException)
                    .AppendRequest(requestStr);
            }

            MethodInfo methodInfo;
            object serviceInstance;
            try
            {
                Type serviceType = _options.ServiceProvider.ResolveService(glueCall.Service);

                methodInfo = _options.ServiceProvider.ResolveMethod(serviceType, glueCall.Method);
                serviceInstance = _options.ServiceProvider.GetInstance(serviceType);
            }
            catch (Exception exception)
            {
                throw new GlueException("Failed to resolve requested service", exception)
                    .AppendServiceName(glueCall.Service)
                    .AppendMethodName(glueCall.Method);
            }

            ParameterInfo[] parameters = methodInfo.GetParameters();
            object[] arguments = glueCall.Arguments?
                .Select(argument =>
                {
                    ParameterInfo parameter = parameters.SingleOrDefault(param =>
                        string.Equals(param.Name, argument.Name, StringComparison.InvariantCultureIgnoreCase));

                    if (parameter == null)
                    {
                        throw new GlueException("Argument not found", null)
                            .AppendServiceName(glueCall.Service)
                            .AppendMethodName(glueCall.Method)
                            .AppendArgumentName(argument.Name);
                    }

                    try
                    {
                        return SerializationHelper.DeserializeObject(argument.Value, parameter.ParameterType);
                    }
                    catch (JsonException jsonException)
                    {
                        throw new GlueException("Failed to deserialize argument", jsonException)
                            .AppendServiceName(glueCall.Service)
                            .AppendMethodName(glueCall.Method)
                            .AppendArgumentName(argument.Name);
                    }
                })
                .ToArray();

            bool isVoid = false;
            bool isTask = false;
            Type returnType = methodInfo.ReturnParameter.ParameterType;

            if (returnType == typeof(void))
            {
                isVoid = true;
            }
            else if (returnType.IsGenericType && 
                     returnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                isTask = true;
            }
            else if (returnType == typeof(Task))
            {
                isTask = true;
                isVoid = true;
            }

            object result = null;

            try
            {
                if (isTask)
                {
                    Task task = (Task) methodInfo.Invoke(serviceInstance, arguments);
                    await task.ConfigureAwait(false);

                    if (!isVoid)
                    {
                        // TODO: remove dynamic
                        result = returnType.GetProperty("Result").GetValue(task);
                    }
                }
                else
                {
                    result = methodInfo.Invoke(serviceInstance, arguments);
                }
            }
            catch (Exception exception)
            {
                Exception toRethrow;
                
                switch (exception)
                {
                    case TargetInvocationException targetInvocationException:
                        toRethrow = targetInvocationException.InnerException;
                        break;
                    
                    default:
                        toRethrow = exception;
                        break;
                }
                
                throw new GlueException("Failed to invoke service method", toRethrow)
                    .AppendServiceName(glueCall.Service)
                    .AppendMethodName(glueCall.Method);
            }

            return result;
        }
    }
}