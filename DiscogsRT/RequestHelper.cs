using BeeWee.DiscogsRT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT
{
    internal static class RequestHelper
    {
        public static string BuildUri(string baseUri, string endpoint)
        {
            return BuildUri(baseUri, endpoint, null);
        }

        public static string BuildUri(string baseUri, string endpoint, Dictionary<string, string> parameters)
        {
            var uriBuilder = new StringBuilder();
            bool firstParam = true;

            uriBuilder.AppendFormat("{0}{1}", baseUri, endpoint);

            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    uriBuilder.AppendFormat("{0}{1}={2}", firstParam ? "?" : "&", parameter.Key, parameter.Value);
                    firstParam = false;
                }
            }

            return uriBuilder.ToString();
        }

        public static async Task<DiscogsResponse<string>> ReadResponse(HttpResponseMessage response)
        {
            var discogsResponse = new DiscogsResponse<string>();

            var content = await response.Content.ReadAsStringAsync();

            discogsResponse.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                discogsResponse.Data = content;
            }
            else
            {
                discogsResponse.ErrorMessage = content;
            }

            return discogsResponse;
        }

        public static async Task<Models.DiscogsResponse<T>> ReadJsonResponse<T>(HttpResponseMessage response) where T : new()
        {
            var discogsResponse = new Models.DiscogsResponse<T>();

            var content = await response.Content.ReadAsStringAsync();

            discogsResponse.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                discogsResponse.Data = JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                discogsResponse.ErrorMessage = content;
            }

            return discogsResponse;
        }
    }
}
