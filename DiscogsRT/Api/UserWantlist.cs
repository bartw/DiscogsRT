using BeeWee.DiscogsRT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Api
{
    public class UserWantlist : Base
    {
        internal UserWantlist(Rester.IClient client, string baseUri, string userAgent, string consumerKey, string consumerSecret)
            : base(client, baseUri, userAgent, consumerKey, consumerSecret)
        {

        }

        public async Task<DiscogsResponse<WantResults>> GetWants(string username, int perPage = -1, int page = -1)
        {
            var endpoint = string.Format("/users/{0}/wants", username);
            var parameters = new Dictionary<string, string>();

            if (perPage > 0)
            {
                parameters.Add("per_page", perPage.ToString());
            }

            if (page > 0)
            {
                parameters.Add("page", page.ToString());
            }

            return await GetOAuth<WantResults>(endpoint, parameters, null);
        }

        public object CreateWant(string username, string id)
        {
            return null;
        }

        public object EditWant(string username, string id)
        {
            return null;
        }

        public object DeleteWant(string username, string id)
        {
            return null;
        }
    }
}
