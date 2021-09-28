using System.Runtime.Serialization;

namespace Glue.Common.Models.Remote
{
    /// <summary>
    /// Base class for all classes for remote calls.
    /// </summary>
    [DataContract]
    public abstract class GlueBase
    {
        /// <summary>
        /// Version of Glue.
        /// See <see cref="Constants.GlueVersion"/>.
        /// </summary>
        [DataMember(Name = "glueVersion")]
        public int GlueVersion { get; set; }
    }
}