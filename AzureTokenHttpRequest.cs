using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Inno.Business.Models.Common;

namespace Inno.Azure
{
    public class AzureTokenHttpRequest
    {
        public static async Task<ResponseView> RequestTokenAsync(AzureAuthStore auth)
        {
            var credentials = new Dictionary<string, string>
            {
                { "grant_type", auth.AzureGrantType },
                { "client_id", auth.AzureClientId },
                { "client_secret", auth.AzureSecret },
                { "scope", auth.AzureLoginScope }
            };

            using var client = new HttpClient();
            //using var azureRequest = new HttpRequestMessage(HttpMethod.Post, auth.AzureTokenEndpoint());
            //azureRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new FormUrlEncodedContent(credentials);

            // todo - check for network connection - mitigate server fail
            var responseMessage = await client.PostAsync(auth.AzureTokenEndpoint(), content).ConfigureAwait(true);

            var azureResponse = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(true);

            return new ResponseView
            {
                Code = responseMessage.StatusCode,
                IsSuccessStatusCode = responseMessage.IsSuccessStatusCode,
                Message = azureResponse
            };
        }
    }
}