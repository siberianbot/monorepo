using System;
using Glue.Common.Helpers;
using Glue.Common.Models.Remote;

namespace Glue.Common.Infrastructure
{
    public static class GlueCallResponseFactory
    {
        public static GlueCallResponse Create(bool isSuccessful, object data)
        {
            return new GlueCallResponse
            {
                GlueVersion = Constants.GlueVersion,
                IsSuccessful = isSuccessful,
                DataType = data?.GetType().FullName,
                Data = data != null ? SerializationHelper.SerializeObject(data) : null
            };
        }

        /// <remarks>Exception is unsuccessful result a priori.</remarks>
        public static GlueCallResponse Create(Exception exception)
        {
            return Create(false, exception);
        }
    }
}