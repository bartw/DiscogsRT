using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Result
    {
        public string thumb { get; set; }
        public string title { get; set; }
        public string uri { get; set; }
        public string resource_url { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public List<string> style { get; set; }
        public List<string> format { get; set; }
        public string country { get; set; }
        public List<string> barcode { get; set; }
        public Community community { get; set; }
        public List<string> label { get; set; }
        public string catno { get; set; }
        public string year { get; set; }
        public List<string> genre { get; set; }
    }
}
