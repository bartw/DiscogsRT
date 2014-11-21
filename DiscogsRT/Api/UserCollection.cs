using BeeWee.DiscogsRT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Api
{
    public class UserCollection : Base
    {
        internal UserCollection(Rester.IClient client, string baseUri, string userAgent, string consumerKey, string consumerSecret)
            : base(client, baseUri, userAgent, consumerKey, consumerSecret)
        {

        }

        public object GetFolders(string username)
        {
            return null;
        }

        public object CreateFolder(string username, object folder)
        {
            return null;
        }

        public object GetFolder(string username, string id)
        {
            return null;
        }

        public object EditFolder(string username, string id)
        {
            return null;
        }

        public object DeleteFolder(string username, string id)
        {
            return null;
        }

        public async Task<DiscogsResponse<CollectionResults>> GetFolderReleases(string username, int id = 0, int perPage = -1, int page = -1)
        {
            var endpoint = string.Format("/users/{0}/collection/folders/{1}/releases", username, id);
            var parameters = new Dictionary<string, string>();

            if (perPage > 0)
            {
                parameters.Add("per_page", perPage.ToString());
            }

            if (page > 0)
            {
                parameters.Add("page", page.ToString());
            }

            return await GetOAuth<CollectionResults>(endpoint, parameters, null);
        }

        public object CreateFolderReleaseInstance(string username, string folderId, string releaseId)
        {
            return null;
        }

        public object EditFolderReleaseInstanceRating(string username, string folderId, string releaseId, string instanceId, object rating)
        {
            return null;
        }

        public object DeleteFolderReleaseInstance(string username, string folderId, string releaseId, string instanceId)
        {
            return null;
        }

        public object GetCustomFields(string username)
        {
            return null;
        }

        public object EditFolderReleaseInstanceField(string username, string folderId, string releaseId, string instanceId, string fieldId, object field)
        {
            return null;
        }
    }
}
