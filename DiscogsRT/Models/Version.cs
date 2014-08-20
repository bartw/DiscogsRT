using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Version
    {
        public string status { get; set; }
        public string thumb { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string format { get; set; }
        public string label { get; set; }
        public string released { get; set; }
        public string catno { get; set; }
        public string resource_url { get; set; }
        public int id { get; set; }
    }
}
