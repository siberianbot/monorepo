using System;
using Newtonsoft.Json;
using Glue.Common.Models.Remote;

namespace Glue.Common.Helpers
{
    public static class SerializationHelper
    {
        public static string SerializeObject<TType>(TType value)
        {
            return JsonConvert.SerializeObject(value, typeof(TType), null);
        }

        public static string SerializeObject(object value, Type type)
        {
            return JsonConvert.SerializeObject(value, type, null);
        }

        public static TType DeserializeObject<TType>(string json)
        {
            return JsonConvert.DeserializeObject<TType>(json);
        }

        public static object DeserializeObject(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        public static string SerializeGlueCall(GlueCall glueCall)
        {
            return SerializeObject(glueCall, typeof(GlueCall));
        }

        public static GlueCall DeserializeGlueCall(string requestStr)
        {
            return DeserializeObject<GlueCall>(requestStr);
        }

        public static string SerializeGlueCallResponse(GlueCallResponse glueCallResponse)
        {
            return SerializeObject(glueCallResponse, typeof(GlueCallResponse));
        }

        public static GlueCallResponse DeserializeGlueCallResponse(string glueCallResponseJson)
        {
            return DeserializeObject<GlueCallResponse>(glueCallResponseJson);
        }
    }
}