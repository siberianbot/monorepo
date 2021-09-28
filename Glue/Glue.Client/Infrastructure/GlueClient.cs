using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Glue.Client.Models;
using Glue.Common;
using Glue.Common.Extensions;
using Glue.Common.Helpers;
using Glue.Common.Models;
using Glue.Common.Models.Remote;
using Newtonsoft.Json;

namespace Glue.Client.Infrastructure
{
    public sealed class GlueClient
    {
        private readonly GlueClientOptions _options;

        public GlueClient(GlueClientOptions options)
        {
            _options = options;
        }

        public async Task<GlueCallResponse> CallServiceAsync(GlueCall glueCall)
        {
            using HttpClient httpClient = new HttpClient();
            using HttpContent httpContent = new StringContent(SerializationHelper.SerializeGlueCall(glueCall),
                Encoding.UTF8, Constants.GlueContentType);

            string responseStr = null;

            try
            {
                using (HttpResponseMessage responseMessage = await httpClient.PostAsync(_options.Endpoint, httpContent))
                {
                    responseStr = await responseMessage.Content.ReadAsStringAsync();
                }

                return SerializationHelper.DeserializeGlueCallResponse(responseStr);
            }
            catch (HttpRequestException httpRequestException)
            {
                throw new GlueException("Failed to perform service call due to HTTP exception", httpRequestException);
            }
            catch (JsonException jsonException)
            {
                throw new GlueException("Failed to deserialize service call response", jsonException)
                    .AppendResponse(responseStr);
            }
        }
    }
}