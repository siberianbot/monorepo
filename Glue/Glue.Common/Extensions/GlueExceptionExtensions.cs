using Glue.Common.Models;

namespace Glue.Common.Extensions
{
    public static class GlueExceptionExtensions
    {
        private const string Request = "Request";
        private const string Response = "Response";

        private const string ServiceName = "ServiceName";
        private const string MethodName = "MethodName";
        private const string ArgumentName = "ArgumentName";

        #region Append data

        public static GlueException AppendRequest(this GlueException @this, string request)
        {
            @this.Data[Request] = request;

            return @this;
        }

        public static GlueException AppendResponse(this GlueException @this, string response)
        {
            @this.Data[Response] = response;

            return @this;
        }

        public static GlueException AppendServiceName(this GlueException @this, string serviceName)
        {
            @this.Data[ServiceName] = serviceName;

            return @this;
        }

        public static GlueException AppendMethodName(this GlueException @this, string methodName)
        {
            @this.Data[MethodName] = methodName;

            return @this;
        }

        public static GlueException AppendArgumentName(this GlueException @this, string methodName)
        {
            @this.Data[MethodName] = methodName;

            return @this;
        }

        #endregion

        #region Get Data data

        public static string GetRequest(this GlueException @this)
        {
            return (string) @this.Data[Request];
        }

        public static string GetResponse(this GlueException @this)
        {
            return (string) @this.Data[Response];
        }

        public static string GetServiceName(this GlueException @this)
        {
            return (string) @this.Data[ServiceName];
        }

        public static string GetMethodName(this GlueException @this)
        {
            return (string) @this.Data[MethodName];
        }

        public static string GetArgumentName(this GlueException @this)
        {
            return (string) @this.Data[ArgumentName];
        }

        #endregion
    }
}