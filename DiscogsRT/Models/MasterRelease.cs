using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class MasterRelease
    {
        public List<string> styles { get; set; }
        public List<string> genres { get; set; }
        public string title { get; set; }
        public int main_release { get; set; }
        public string main_release_url { get; set; }
        public string uri { get; set; }
        public List<Artist> artists { get; set; }
        public string versions_url { get; set; }
        public int year { get; set; }
        public List<Image> images { get; set; }
        public string resource_url { get; set; }
        public List<Tracklist> tracklist { get; set; }
        public int id { get; set; }
        public string data_quality { get; set; }
    }
}
