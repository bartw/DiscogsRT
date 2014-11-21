using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace BeeWee.DiscogsRT.Api
{
    public abstract class Base
    {
        private const string UserAgentHeader = "User-Agent";

        private Rester.IClient _client;
        private string _baseUri;
        private string _userAgent;
        private string _consumerKey;
        private string _consumerSecret;
        private string _oauthKey;
        private string _oauthSecret;

        internal Base(Rester.IClient client, string baseUri, string userAgent, string consumerKey, string consumerSecret)
        {
            _client = client;
            _baseUri = baseUri;
            _userAgent = userAgent;
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
        }

        internal void Authenticate(string oauthKey, string oauthSecret)
        {
            _oauthKey = oauthKey;
            _oauthSecret = oauthSecret;
        }

        protected async Task<Models.DiscogsResponse<string>> Get(string endpoint, Dictionary<string, string> parameters, Dictionary<string, string> headers)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            if (!headers.ContainsKey(UserAgentHeader))
            {
                headers.Add(UserAgentHeader, _userAgent);
            }

            var uri = RequestHelper.BuildUri(_baseUri, endpoint, parameters);

            var request = new Rester.Request() { Method = HttpMethod.Get, Uri = uri, Headers = headers };
            var response = await _client.ExecuteAsync(request);
            var discogsResponse = await RequestHelper.ReadResponse(response);

            return discogsResponse;
        }

        protected async Task<Models.DiscogsResponse<string>> GetOAuth(string endpoint, Dictionary<string, string> parameters, Dictionary<string, string> headers)
        {
            return await GetOAuth(endpoint, parameters, headers, _oauthKey, _oauthSecret, null);
        }

        protected async Task<Models.DiscogsResponse<string>> GetOAuth(string endpoint, Dictionary<string, string> parameters, Dictionary<string, string> headers, string oauthKey, string oauthSecret, string verifier)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            if (!headers.ContainsKey(UserAgentHeader))
            {
                headers.Add(UserAgentHeader, _userAgent);
            }

            var uri = RequestHelper.BuildUri(_baseUri, endpoint, parameters);
            
            var request = new Rester.Request() { Method = HttpMethod.Get, Uri = uri, Headers = headers, ConsumerKey = _consumerKey, ConsumerSecret = _consumerSecret, OAuthKey = oauthKey, OAuthSecret = oauthSecret, Verifier = verifier, SignatureMethod = Rester.SignatureMethod.PLAINTEXT };
            var response = await _client.ExecuteAsync(request);
            var discogsResponse = await RequestHelper.ReadResponse(response);

            return discogsResponse;
        }

        protected async Task<Models.DiscogsResponse<T>> Get<T>(string endpoint, Dictionary<string, string> parameters, Dictionary<string, string> headers) where T : new()
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            if (!headers.ContainsKey(UserAgentHeader))
            {
                headers.Add(UserAgentHeader, _userAgent);
            }

            var uri = RequestHelper.BuildUri(_baseUri, endpoint, parameters);
            var request = new Rester.Request() { Method = HttpMethod.Get, Uri = uri, Headers = headers };
            var response = await _client.ExecuteAsync(request);
            var discogsResponse = await RequestHelper.ReadJsonResponse<T>(response);

            return discogsResponse;
        }

        protected async Task<Models.DiscogsResponse<T>> GetOAuth<T>(string endpoint, Dictionary<string, string> parameters, Dictionary<string, string> headers) where T : new()
        {
            return await GetOAuth<T>(endpoint, parameters, headers, _oauthKey, _oauthSecret, null);
        }

        protected async Task<Models.DiscogsResponse<T>> GetOAuth<T>(string endpoint, Dictionary<string, string> parameters, Dictionary<string, string> headers, string oauthKey, string oauthSecret, string verifier) where T : new()
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            if (!headers.ContainsKey(UserAgentHeader))
            {
                headers.Add(UserAgentHeader, _userAgent);
            }

            var uri = RequestHelper.BuildUri(_baseUri, endpoint, parameters);
            var request = new Rester.Request() { Method = HttpMethod.Get, Uri = uri, Headers = headers, ConsumerKey = _consumerKey, ConsumerSecret = _consumerSecret, OAuthKey = oauthKey, OAuthSecret = oauthSecret, Verifier = verifier, SignatureMethod = Rester.SignatureMethod.PLAINTEXT };
            var response = await _client.ExecuteAsync(request);
            var discogsResponse = await RequestHelper.ReadJsonResponse<T>(response);

            return discogsResponse;
        }
    }
}
