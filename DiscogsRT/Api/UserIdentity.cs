using BeeWee.DiscogsRT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Api
{
    public class UserIdentity : Base
    {
        internal UserIdentity(string baseUri, string userAgent, string consumerKey, string consumerSecret)
            : base(baseUri, userAgent, consumerKey, consumerSecret)
        {

        }

        public async Task<DiscogsResponse<Identity>> GetIdentity()
        {
            var endpoint = string.Format("/oauth/identity");
            return await GetOAuth<Identity>(endpoint, null, null);
        }

        public async Task<DiscogsResponse<Profile>> GetProfile(string username)
        {
            var endpoint = string.Format("/users/{0}", username);
            return await GetOAuth<Profile>(endpoint, null, null);
        }

        public object EditProfile(string username)
        {
            return null;
        }

        public async Task<DiscogsResponse<string>> GetUserSubmissions(string username)
        {
            var endpoint = string.Format("/users/{0}/submissions", username);
            return await GetOAuth(endpoint, null, null);
        }

        public async Task<DiscogsResponse<string>> GetUserContributions(string username)
        {
            var endpoint = string.Format("/users/{0}/contributions", username);
            return await GetOAuth(endpoint, null, null);
        }
    }
}
