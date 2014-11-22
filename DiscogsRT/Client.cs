using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT
{
    public class Client
    {
        private ApiService _api;
        private string _consumerKey;
        private string _consumerSecret;

        public Client(string userAgent, string consumerKey, string consumerSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;

            _api = new ApiService(userAgent);
        }

        #region Authentication
        public async Task<Models.DiscogsResponse<string>> GetRequestTokenAsync()
        {
            return await _api.GetAsync("/oauth/request_token");
        }
        public async Task<Models.RequestToken> GetOAuthRequestAsync()
        {
            var request = new Models.RequestToken();

            var requestTokenString = await GetRequestTokenAsync();

            if (requestTokenString != null && !string.IsNullOrWhiteSpace(requestTokenString.Data))
            {
                var splitted = requestTokenString.Data.Split('&').Select(s => s.Split('=')).ToDictionary(s => s.First(), s => s.Last());

                request.Key = splitted["oauth_token"];
                request.Secret = splitted["oauth_token_secret"];

                request.Uri = string.Format("http://www.discogs.com/oauth/authorize?oauth_token={0}", request.Key);
            }

            return request;
        }
        public async Task<Models.DiscogsResponse<string>> GetAccessTokenAsync(string tokenKey, string tokenSecret, string verifier)
        {
            var authenticator = new Rester.OAuth1Authenticator(Rester.SignatureMethod.PLAINTEXT, _consumerKey, _consumerSecret, tokenKey, tokenSecret, verifier);
            return await _api.GetAsync("/oauth/access_token", authenticator: authenticator);
        }
        public async Task<Models.AccessToken> GetOAuthAccesAsync(string tokenKey, string tokenSecret, string verifier)
        {
            var access = new Models.AccessToken();

            var accessTokenString = await GetAccessTokenAsync(tokenKey, tokenSecret, verifier);

            if (accessTokenString != null && !string.IsNullOrWhiteSpace(accessTokenString.Data))
            {
                var splitted = accessTokenString.Data.Split('&').Select(s => s.Split('=')).ToDictionary(s => s.First(), s => s.Last());

                access.Key = splitted["oauth_token"];
                access.Secret = splitted["oauth_token_secret"];
            }

            return access;
        }
        #endregion
        #region User
        public async Task<Models.DiscogsResponse<Models.Identity>> GetIdentityAsync(string tokenKey, string tokenSecret)
        {
            var authenticator = new Rester.OAuth1Authenticator(Rester.SignatureMethod.PLAINTEXT, _consumerKey, _consumerSecret, tokenKey, tokenSecret);
            return await _api.GetAsync<Models.Identity>("/oauth/identity", authenticator: authenticator);
        }
        public async Task<Models.DiscogsResponse<Models.Profile>> GetProfileAsync(string tokenKey, string tokenSecret, string username)
        {
            var endpoint = string.Format("/users/{0}", username);
            var authenticator = new Rester.OAuth1Authenticator(Rester.SignatureMethod.PLAINTEXT, _consumerKey, _consumerSecret, tokenKey, tokenSecret);
            return await _api.GetAsync<Models.Profile>(endpoint, authenticator: authenticator);
        }
        #endregion
        #region Wantlist
        public async Task<Models.DiscogsResponse<Models.WantResults>> GetWantsAsync(string tokenKey, string tokenSecret, string username, int perPage = -1, int page = -1)
        {
            var endpoint = string.Format("/users/{0}/wants", username);
            var authenticator = new Rester.OAuth1Authenticator(Rester.SignatureMethod.PLAINTEXT, _consumerKey, _consumerSecret, tokenKey, tokenSecret);
            var parameters = new Dictionary<string, string>();

            if (perPage > 0)
            {
                parameters.Add("per_page", perPage.ToString());
            }

            if (page > 0)
            {
                parameters.Add("page", page.ToString());
            }

            return await _api.GetAsync<Models.WantResults>(endpoint, parameters, authenticator);
        }
        #endregion
        #region Collection
        public async Task<Models.DiscogsResponse<Models.CollectionResults>> GetFolderReleasesAsync(string tokenKey, string tokenSecret, string username, int id = 0, int perPage = -1, int page = -1)
        {
            var endpoint = string.Format("/users/{0}/collection/folders/{1}/releases", username, id);
            var authenticator = new Rester.OAuth1Authenticator(Rester.SignatureMethod.PLAINTEXT, _consumerKey, _consumerSecret, tokenKey, tokenSecret);
            var parameters = new Dictionary<string, string>();

            if (perPage > 0)
            {
                parameters.Add("per_page", perPage.ToString());
            }

            if (page > 0)
            {
                parameters.Add("page", page.ToString());
            }

            return await _api.GetAsync<Models.CollectionResults>(endpoint, parameters, authenticator);
        }
        #endregion
        #region Database
        public async Task<Models.DiscogsResponse<Models.Release>> GetReleaseAsync(string id)
        {
            var endpoint = string.Format("/releases/{0}", id);
            return await _api.GetAsync<Models.Release>(endpoint);
        }
        public async Task<Models.DiscogsResponse<Models.MasterRelease>> GetMasterReleaseAsync(string id)
        {
            var endpoint = string.Format("/masters/{0}", id);
            return await _api.GetAsync<Models.MasterRelease>(endpoint);
        }
        public async Task<Models.DiscogsResponse<Models.MasterReleaseVersions>> GetMasterReleaseVersionsAsync(string id)
        {
            var endpoint = string.Format("/masters/{0}/versions", id);
            return await _api.GetAsync<Models.MasterReleaseVersions>(endpoint);
        }
        public async Task<Models.DiscogsResponse<Models.Artist>> GetArtistAsync(string id)
        {
            var endpoint = string.Format("/artists/{0}", id);
            return await _api.GetAsync<Models.Artist>(endpoint);
        }
        public async Task<Models.DiscogsResponse<Models.ArtistReleases>> GetArtistReleasesAsync(string id)
        {
            var endpoint = string.Format("/artists/{0}/releases", id);
            return await _api.GetAsync<Models.ArtistReleases>(endpoint);
        }
        public async Task<Models.DiscogsResponse<Models.Label>> GetLabelAsync(string id)
        {
            var endpoint = string.Format("/label/{0}", id);
            return await _api.GetAsync<Models.Label>(endpoint);
        }
        public async Task<Models.DiscogsResponse<Models.LabelReleases>> GetLabelReleasesAsync(string id)
        {
            var endpoint = string.Format("/labels/{0}/releases", id);
            return await _api.GetAsync<Models.LabelReleases>(endpoint);
        }
        public async Task<Models.DiscogsResponse<Models.SearchResults>> Search(string tokenKey, string tokenSecret, Models.SearchQuery query, int perPage = -1, int page = -1)
        {
            var authenticator = new Rester.OAuth1Authenticator(Rester.SignatureMethod.PLAINTEXT, _consumerKey, _consumerSecret, tokenKey, tokenSecret);
            var parameters = query.GetParameters();

            if (perPage > 0)
            {
                parameters.Add("per_page", perPage.ToString());
            }

            if (page > 0)
            {
                parameters.Add("page", page.ToString());
            }

            return await _api.GetAsync<Models.SearchResults>("/database/search", parameters, authenticator);
        }
        #endregion
        #region Marketplace
        #endregion
        #region Images
        #endregion
    }
}