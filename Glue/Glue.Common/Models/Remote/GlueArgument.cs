using System.Runtime.Serialization;

namespace Glue.Common.Models.Remote
{
    /// <summary>
    /// Method argument class.
    /// </summary>
    [DataContract]
    public sealed class GlueArgument : GlueBase
    {
        /// <summary>
        /// Argument name.
        /// Case-sensitive.
        /// </summary>
        [DataMember(Name = "argName")]
        public string Name { get; set; }

        /// <summary>
        /// Argument value.
        /// Should be valid JSON.
        /// </summary>
        [DataMember(Name = "argValue")]
        public string Value { get; set; }
    }
}