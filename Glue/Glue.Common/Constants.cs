namespace Glue.Common
{
    /// <summary>
    /// Constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Version of Glue protocol.
        /// Version mismatch should be processed as error.
        /// </summary>
        public const int GlueVersion = 1;

        /// <summary>
        /// Content type for all Glue requests/responses.
        /// Content type mismatch should be processed as error.
        /// </summary>
        public const string GlueContentType = "application/json";

        /// <summary>
        /// Default endpoint for Glue client and server.
        /// Just for convention.
        /// </summary>
        public const string GlueEndpoint = "http://localhost:8080/glue/";
    }
}