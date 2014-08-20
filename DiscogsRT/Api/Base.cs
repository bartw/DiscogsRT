using System;
using System.Collections.Generic;
using System.Linq;
//using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using Windows.Web.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BeeWee.DiscogsRT.Api
{
    public abstract class Base
    {
        private const string UserAgentHeader = "User-Agent";

        private string _baseUri;
        private string _userAgent;
        private string _consumerKey;
        private string _consumerSecret;
        private string _oauthKey;
        private string _oauthSecret;
        private Rester.Client _client;

        internal Base(string baseUri, string userAgent, string consumerKey, string consumerSecret)
        {
            _baseUri = baseUri;
            _userAgent = userAgent;
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _client = new Rester.Client();
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
            var response = await _client.Get(uri, headers);
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
            var response = await _client.Get(uri, headers, _consumerKey, _consumerSecret, oauthKey, oauthSecret, verifier);
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
            var response = await _client.Get(uri, headers);
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
            var response = await _client.Get(uri, headers, _consumerKey, _consumerSecret, oauthKey, oauthSecret, verifier);
            var discogsResponse = await RequestHelper.ReadJsonResponse<T>(response);

            return discogsResponse;
        }
    }
}
