using System;
using Accounting.Common;
using Accounting.Service.Models;

namespace Accounting.Service.Builders.Implementation
{
    internal sealed class ServiceMethodBuilder : IServiceMethodBuilder
    {
        private string _method;
        private string _path;
        private Type _modelType;
        private Type _resultType;

        public IServiceMethodBuilder WithEndpoint(string method, string path)
        {
            Assert.IsNotEmpty(method, "method is empty");
            Assert.IsNotEmpty(path, "path is empty");
            Assert.IsEmpty(_method, "method is already defined");
            Assert.IsEmpty(_path, "path is already defined");

            _method = method;
            _path = path;

            return this;
        }

        public IServiceMethodBuilder WithModel<TModel>()
        {
            Assert.IsNull(_modelType, "model type is already defined");

            _modelType = typeof(TModel);

            return this;
        }

        public IServiceMethodBuilder WithResult<TResult>()
        {
            Assert.IsNull(_resultType, "result type is already defined");

            _resultType = typeof(TResult);

            return this;
        }

        public ServiceMethodEndpoint Build()
        {
            Assert.IsNotEmpty(_method, "method is not defined");
            Assert.IsNotEmpty(_path, "path is not defined");
            Assert.IsNotNull(_modelType, "model type is not defined");
            Assert.IsNotNull(_resultType, "result type is not defined");

            return new ServiceMethodEndpoint
            {
                Method = _method,
                Path = _path,
                ModelType = _modelType,
                ResultType = _resultType
            };
        }
    }
}