using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT
{
    internal class ApiService
    {
        private readonly string _baseUri = "https://api.discogs.com";
        private readonly string _userAgentKey = "User-Agent";
        private string _userAgent;
        private Rester.IClient _rester;

        public ApiService(string userAgent)
        {
            _userAgent = userAgent;
            _rester = new Rester.ThrottledClient(1, TimeSpan.FromSeconds(1));
        }

        public async Task<Models.DiscogsResponse<T>> GetAsync<T>(string endpoint, Dictionary<string, string> parameters = null, Rester.IAuthenticator authenticator = null) where T : new()
        {
            HttpResponseMessage response = await GetRawAsync(endpoint, parameters, authenticator);
            var discogsResponse = await ReadJsonResponse<T>(response);

            return discogsResponse;
        }

        public async Task<Models.DiscogsResponse<string>> GetAsync(string endpoint, Dictionary<string, string> parameters = null, Rester.IAuthenticator authenticator = null)
        {
            HttpResponseMessage response = await GetRawAsync(endpoint, parameters, authenticator);
            var discogsResponse = await ReadResponse(response);

            return discogsResponse;
        }

        public async Task<Models.DiscogsResponse<T>> PostAsync<T>(string endpoint, Dictionary<string, string> parameters = null, Rester.IAuthenticator authenticator = null, string content = null) where T : new()
        {
            HttpResponseMessage response = await PostRawAsync(endpoint, parameters, authenticator, content);
            var discogsResponse = await ReadJsonResponse<T>(response);

            return discogsResponse;
        }

        public async Task<Models.DiscogsResponse<T>> PutAsync<T>(string endpoint, Dictionary<string, string> parameters = null, Rester.IAuthenticator authenticator = null, string content = null) where T : new()
        {
            HttpResponseMessage response = await PutRawAsync(endpoint, parameters, authenticator, content);
            var discogsResponse = await ReadJsonResponse<T>(response);

            return discogsResponse;
        }

        public async Task<Models.DiscogsResponse<string>> DeleteAsync(string endpoint, Dictionary<string, string> parameters = null, Rester.IAuthenticator authenticator = null)
        {
            HttpResponseMessage response = await DeleteRawAsync(endpoint, parameters, authenticator);
            var discogsResponse = await ReadResponse(response);

            return discogsResponse;
        }

        private async Task<HttpResponseMessage> GetRawAsync(string endpoint, Dictionary<string, string> parameters, Rester.IAuthenticator authenticator)
        {
            var request = new Rester.GetRequest(BuildUri(endpoint, parameters));
            return await ExecuteAsync(request, authenticator);
        }

        private async Task<HttpResponseMessage> PostRawAsync(string endpoint, Dictionary<string, string> parameters, Rester.IAuthenticator authenticator, string content)
        {
            var request = new Rester.PostRequest(BuildUri(endpoint, parameters), content, Encoding.UTF8, "application/json");
            return await ExecuteAsync(request, authenticator);
        }

        private async Task<HttpResponseMessage> PutRawAsync(string endpoint, Dictionary<string, string> parameters, Rester.IAuthenticator authenticator, string content)
        {
            var request = new Rester.PutRequest(BuildUri(endpoint, parameters), content, Encoding.UTF8, "application/json");
            return await ExecuteAsync(request, authenticator);
        }

        private async Task<HttpResponseMessage> DeleteRawAsync(string endpoint, Dictionary<string, string> parameters, Rester.IAuthenticator authenticator)
        {
            var request = new Rester.DeleteRequest(BuildUri(endpoint, parameters));
            return await ExecuteAsync(request, authenticator);
        }

        private async Task<HttpResponseMessage> ExecuteAsync(Rester.Request request, Rester.IAuthenticator authenticator)
        {
            request.Headers.Add(_userAgentKey, _userAgent);

            return await _rester.ExecuteRawAsync(request, authenticator);
        }

        private string BuildUri(string endpoint, Dictionary<string, string> parameters)
        {
            var uriBuilder = new StringBuilder();

            uriBuilder.Append(_baseUri);
            uriBuilder.Append(endpoint);

            bool firstParam = true;

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

        private async Task<Models.DiscogsResponse<T>> ReadJsonResponse<T>(HttpResponseMessage response) where T : new()
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

        public static async Task<Models.DiscogsResponse<string>> ReadResponse(HttpResponseMessage response)
        {
            var discogsResponse = new Models.DiscogsResponse<string>();

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

        public async Task<HttpResponseMessage> GetAsyncHttp(string endpoint, Dictionary<string, string> parameters = null, Rester.IAuthenticator authenticator = null)
        {
            HttpResponseMessage response = await GetRawAsyncHttp(endpoint, parameters, authenticator);
            response.EnsureSuccessStatusCode();
            return response;
        }

        private async Task<HttpResponseMessage> GetRawAsyncHttp(string endpoint, Dictionary<string, string> parameters, Rester.IAuthenticator authenticator)
        {
            var request = new Rester.GetRequest(BuildUriImage(endpoint, parameters));
            return await ExecuteAsync(request, authenticator);
        }

        private string BuildUriImage(string endpoint, Dictionary<string, string> parameters)
        {
            var uriBuilder = new StringBuilder();

            // dont use base for Images uriBuilder.Append(_baseUri);

            uriBuilder.Append(endpoint);

            bool firstParam = true;

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
    }
}
