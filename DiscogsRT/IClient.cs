using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT
{
    public interface IClient
    {
        #region Authentication
        Task<Models.DiscogsResponse<string>> GetRequestTokenAsync();
        Task<Models.RequestToken> GetOAuthRequestAsync();
        Task<Models.DiscogsResponse<string>> GetAccessTokenAsync(string tokenKey, string tokenSecret, string verifier);
        Task<Models.AccessToken> GetOAuthAccesAsync(string tokenKey, string tokenSecret, string verifier);
        #endregion
        #region User
        Task<Models.DiscogsResponse<Models.Identity>> GetIdentityAsync(string tokenKey, string tokenSecret);
        Task<Models.DiscogsResponse<Models.Profile>> GetProfileAsync(string tokenKey, string tokenSecret, string username);
        #endregion
        #region Wantlist
        Task<Models.DiscogsResponse<Models.WantResults>> GetWantsAsync(string tokenKey, string tokenSecret, string username, int perPage = -1, int page = -1);
        #endregion
        #region Collection
        Task<Models.DiscogsResponse<Models.CollectionResults>> GetFolderReleasesAsync(string tokenKey, string tokenSecret, string username, int id = 0, int perPage = -1, int page = -1);
        #endregion
        #region Database
        Task<Models.DiscogsResponse<Models.Release>> GetReleaseAsync(string id);
        Task<Models.DiscogsResponse<Models.MasterRelease>> GetMasterReleaseAsync(string id);
        Task<Models.DiscogsResponse<Models.MasterReleaseVersions>> GetMasterReleaseVersionsAsync(string id);
        Task<Models.DiscogsResponse<Models.Artist>> GetArtistAsync(string id);
        Task<Models.DiscogsResponse<Models.ArtistReleases>> GetArtistReleasesAsync(string id);
        Task<Models.DiscogsResponse<Models.Label>> GetLabelAsync(string id);
        Task<Models.DiscogsResponse<Models.LabelReleases>> GetLabelReleasesAsync(string id);
        Task<Models.DiscogsResponse<Models.SearchResults>> Search(string tokenKey, string tokenSecret, Models.SearchQuery query, int perPage = -1, int page = -1);
        #endregion
        #region Marketplace
        #endregion
        #region Images
        #endregion
    }
}
