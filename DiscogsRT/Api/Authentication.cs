using BeeWee.DiscogsRT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Api
{
    public class Authentication : Base
    {
        internal Authentication(string baseUri, string userAgent, string consumerKey, string consumerSecret)
            : base(baseUri, userAgent, consumerKey, consumerSecret)
        {

        }

        public async Task<DiscogsResponse<string>> GetRequestToken()
        {
            var endpoint = string.Format("/oauth/request_token");
            return await GetOAuth(endpoint, null, null, null, null, null);
        }

        public async Task<OAuthRequest> GetOAuthRequest()
        {
            var request = new OAuthRequest();

            var requestTokenString = await GetRequestToken();

            if (requestTokenString != null && !string.IsNullOrWhiteSpace(requestTokenString.Data))
            {
                var splitted = requestTokenString.Data.Split('&').Select(s => s.Split('=')).ToDictionary(s => s.First(), s => s.Last());

                request.Key = splitted["oauth_token"];
                request.Secret = splitted["oauth_token_secret"];

                request.Uri = string.Format("http://www.discogs.com/oauth/authorize?oauth_token={0}", request.Key);
            }

            return request;
        }

        public async Task<DiscogsResponse<string>> GetAccessToken(string oauthKey, string oauthSecret, string verifier)
        {
            var endpoint = string.Format("/oauth/access_token");
            return await GetOAuth(endpoint, null, null, oauthKey, oauthSecret, verifier);
        }

        public async Task<OAuthAccess> GetOAuthAccess(string oauthKey, string oauthSecret, string verifier)
        {
            var access = new OAuthAccess();

            var accessTokenString = await GetAccessToken(oauthKey, oauthSecret, verifier);

            if (accessTokenString != null && !string.IsNullOrWhiteSpace(accessTokenString.Data))
            {
                var splitted = accessTokenString.Data.Split('&').Select(s => s.Split('=')).ToDictionary(s => s.First(), s => s.Last());

                access.Key = splitted["oauth_token"];
                access.Secret = splitted["oauth_token_secret"];
            }

            return access;
        }
    }
}
