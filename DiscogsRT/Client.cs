using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeeWee.DiscogsRT
{
    public class Client
    {
        private readonly string _baseUri = "http://api.discogs.com";

        public Api.Database Database { get; set; }
        public Api.Authentication Authentication { get; set; }
        public Api.Images Images { get; set; }
        public Api.Marketplace Marketplace { get; set; }
        public Api.UserIdentity UserIdentity { get; set; }
        public Api.UserCollection UserCollection { get; set; }
        public Api.UserWantlist UserWantlist { get; set; }

        public Client(string userAgent, string consumerKey, string consumerSecret)
        {
            Database = new Api.Database(_baseUri, userAgent, consumerKey, consumerSecret);
            Authentication = new Api.Authentication(_baseUri, userAgent, consumerKey, consumerSecret);
            Images = new Api.Images(_baseUri, userAgent, consumerKey, consumerSecret);
            Marketplace = new Api.Marketplace(_baseUri, userAgent, consumerKey, consumerSecret);
            UserIdentity = new Api.UserIdentity(_baseUri, userAgent, consumerKey, consumerSecret);
            UserCollection = new Api.UserCollection(_baseUri, userAgent, consumerKey, consumerSecret);
            UserWantlist = new Api.UserWantlist(_baseUri, userAgent, consumerKey, consumerSecret);
        }

        public void Authenticate(string oauthKey, string oauthSecret)
        {
            Database.Authenticate(oauthKey, oauthSecret);
            Images.Authenticate(oauthKey, oauthSecret);
            Marketplace.Authenticate(oauthKey, oauthSecret);
            UserIdentity.Authenticate(oauthKey, oauthSecret);
            UserCollection.Authenticate(oauthKey, oauthSecret);
            UserWantlist.Authenticate(oauthKey, oauthSecret);
        }
    }
}
