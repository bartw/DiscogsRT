using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Api
{
    public class UserWantlist : Base
    {
        internal UserWantlist(string baseUri, string userAgent, string consumerKey, string consumerSecret)
            : base(baseUri, userAgent, consumerKey, consumerSecret)
        {

        }

        public object GetWants(string username)
        {
            return null;
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
