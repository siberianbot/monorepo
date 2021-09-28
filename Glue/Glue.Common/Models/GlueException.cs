using System;
using System.Collections.Generic;

namespace Glue.Common.Models
{
    /// <summary>
    /// Glue Exception.
    /// Obviously, used for most of Glue exceptions.
    /// </summary>
    public sealed class GlueException : Exception
    {
        /// <summary>
        /// Creates instance of exception with message and inner exception.
        /// </summary>
        /// <param name="msg">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public GlueException(string msg, Exception inner) : base(msg, inner)
        {
            AdditionalData = new Dictionary<string, object>();
        }

        /// <summary>
        /// Additional data of exception, like name of method or service.
        /// </summary>
        public IDictionary<string, object> AdditionalData { get; }
    }
}