using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Video
    {
        public int duration { get; set; }
        public string description { get; set; }
        public bool embed { get; set; }
        public string uri { get; set; }
        public string title { get; set; }
    }
}
