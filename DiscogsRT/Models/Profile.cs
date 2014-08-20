using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Profile
    {
        public string profile { get; set; }
        public string wantlist_url { get; set; }
        public double rank { get; set; }
        public int num_pending { get; set; }
        public int id { get; set; }
        public int num_for_sale { get; set; }
        public string home_page { get; set; }
        public string location { get; set; }
        public string collection_folders_url { get; set; }
        public string username { get; set; }
        public string collection_fields_url { get; set; }
        public int releases_contributed { get; set; }
        public string registered { get; set; }
        public double rating_avg { get; set; }
        public int num_collection { get; set; }
        public int releases_rated { get; set; }
        public int num_lists { get; set; }
        public string name { get; set; }
        public int num_wantlist { get; set; }
        public string inventory_url { get; set; }
        public string uri { get; set; }
        public string avatar_url { get; set; }
        public string resource_url { get; set; }
    }
}
