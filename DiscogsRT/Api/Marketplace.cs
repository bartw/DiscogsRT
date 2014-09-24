using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Api
{
    public class Marketplace : Base
    {
        internal Marketplace(Rester.Client client, string baseUri, string userAgent, string consumerKey, string consumerSecret)
            : base(client, baseUri, userAgent, consumerKey, consumerSecret)
        {

        }

        public object GetInvetory(string username)
        {
            return null;
        }

        public object GetListing(string id)
        {
            return null;
        }

        public object CreateListing(object listing)
        {
            return null;
        }

        public object EditListing(string id, object listing)
        {
            return null;
        }

        public object DeleteListing(string id)
        {
            return null;
        }

        public object GetOrders()
        {
            return null;
        }

        public object GetOrder(string id)
        {
            return null;
        }

        public object EditOrder(string id, object order)
        {
            return null;
        }

        public object GetOrderMessages(string id)
        {
            return null;
        }

        public object CreateOrderMessage(string id, object message)
        {
            return null;
        }

        public object GetFee(string price)
        {
            return null;
        }

        public object GetFee(string price, string currency)
        {
            return null;
        }

        public object GetPriceSuggestions(string id)
        {
            return null;
        }
    }
}
