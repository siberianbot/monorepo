using System.Runtime.Serialization;

namespace Glue.Common.Models.Remote
{
    /// <summary>
    /// Remote call class.
    /// </summary>
    [DataContract]
    public sealed class GlueCall : GlueBase
    {
        /// <summary>
        /// Target service to invoke.
        /// </summary>
        [DataMember(Name = "callService")]
        public string Service { get; set; }
        
        /// <summary>
        /// Target method of service to invoke.
        /// </summary>
        [DataMember(Name = "callMethod")]
        public string Method { get; set; }
        
        /// <summary>
        /// Array of arguments to service method.
        /// </summary>
        [DataMember(Name = "callArgs")]
        public GlueArgument[] Arguments { get; set; }
    }
}