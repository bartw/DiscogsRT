using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Release
    {
        public string status { get; set; }
        public List<string> styles { get; set; }
        public List<Video> videos { get; set; }
        //public List<object> series { get; set; }
        public string released_formatted { get; set; }
        public List<Label> labels { get; set; }
        public int estimated_weight { get; set; }
        public Community community { get; set; }
        public string released { get; set; }
        public string master_url { get; set; }
        public int year { get; set; }
        public List<Image> images { get; set; }
        public string date_added { get; set; }
        public int format_quantity { get; set; }
        public int id { get; set; }
        public List<string> genres { get; set; }
        public string thumb { get; set; }
        public List<Extraartist> extraartists { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string notes { get; set; }
        public List<Identifier> identifiers { get; set; }
        public List<Company> companies { get; set; }
        public string uri { get; set; }
        public List<Artist> artists { get; set; }
        public List<Format> formats { get; set; }
        public string date_changed { get; set; }
        public string resource_url { get; set; }
        public int master_id { get; set; }
        public List<Tracklist> tracklist { get; set; }
        public string data_quality { get; set; }
    }

}
