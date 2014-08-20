using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Api
{
    public class Images : Base
    {
        internal Images(string baseUri, string userAgent, string consumerKey, string consumerSecret)
            : base(baseUri, userAgent, consumerKey, consumerSecret)
        {

        }

        public object GetImage(string filename)
        {
            return null;
        }
    }
}
