using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class BasicInformation
    {
        public List<Label> labels { get; set; }
        public List<Format> formats { get; set; }
        public string thumb { get; set; }
        public string title { get; set; }
        public List<Artist> artists { get; set; }
        public string resource_url { get; set; }
        public int year { get; set; }
        public int id { get; set; }
    }
}
