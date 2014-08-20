using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Image
    {
        public string uri { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string resource_url { get; set; }
        public string type { get; set; }
        public string uri150 { get; set; }
    }
}
