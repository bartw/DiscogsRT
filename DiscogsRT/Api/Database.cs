using BeeWee.DiscogsRT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Api
{
    public class Database : Base
    {
        internal Database(Rester.IClient client, string baseUri, string userAgent, string consumerKey, string consumerSecret)
            : base(client, baseUri, userAgent, consumerKey, consumerSecret)
        {

        }

        public async Task<DiscogsResponse<Release>> GetRelease(string id)
        {
            var endpoint = string.Format("/releases/{0}", id);
            return await Get<Release>(endpoint, null, null);
        }

        public async Task<DiscogsResponse<MasterRelease>> GetMasterRelease(string id)
        {
            var endpoint = string.Format("/masters/{0}", id);
            return await Get<MasterRelease>(endpoint, null, null);
        }

        public async Task<DiscogsResponse<MasterReleaseVersions>> GetMasterReleaseVersions(string id)
        {
            var endpoint = string.Format("/masters/{0}/versions", id);
            return await Get<MasterReleaseVersions>(endpoint, null, null);
        }

        public async Task<DiscogsResponse<Artist>> GetArtist(string id)
        {
            var endpoint = string.Format("/artists/{0}", id);
            return await Get<Artist>(endpoint, null, null);
        }

        public async Task<DiscogsResponse<ArtistReleases>> GetArtistReleases(string id)
        {
            var endpoint = string.Format("/artists/{0}/releases", id);
            return await Get<ArtistReleases>(endpoint, null, null);
        }

        public async Task<DiscogsResponse<Label>> GetLabel(string id)
        {
            var endpoint = string.Format("/labels/{0}", id);
            return await Get<Label>(endpoint, null, null);
        }

        public async Task<DiscogsResponse<LabelReleases>> GetLabelReleases(string id)
        {
            var endpoint = string.Format("/labels/{0}/releases", id);
            return await Get<LabelReleases>(endpoint, null, null);
        }

        public async Task<DiscogsResponse<SearchResults>> Search(SearchQuery query, int perPage = -1, int page = -1)
        {
            var endpoint = string.Format("/database/search");
            var parameters = query.GetParameters();

            var headers = new Dictionary<string, string>();
            
            if (perPage > 0)
            {
                headers.Add("per_page", perPage.ToString());
            }

            if (page > 0)
            {
                headers.Add("page", page.ToString());
            }

            //return await GetOAuth<SearchResults>(endpoint, null, headers);
            return await GetOAuth<SearchResults>(endpoint, parameters, headers);
        }
    }
}
