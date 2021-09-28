using System.Runtime.Serialization;

namespace Glue.Common.Models.Remote
{
    /// <summary>
    /// Remote call response class.
    /// </summary>
    [DataContract]
    public sealed class GlueCallResponse : GlueBase
    {
        /// <summary>
        /// Is call successful?
        /// </summary>
        [DataMember(Name = "callIsSuccessful")]
        public bool IsSuccessful { get; set; }
        
        /// <summary>
        /// Type of response data.
        /// </summary>
        [DataMember(Name = "callResponseDataType")]
        public string DataType { get; set; }
        
        /// <summary>
        /// Response data.
        /// </summary>
        [DataMember(Name = "callResponseData")]
        public string Data { get; set; }
    }
}