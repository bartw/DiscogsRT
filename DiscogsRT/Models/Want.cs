using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Want
    {
        public string notes { get; set; }
        public int rating { get; set; }
        public string resource_url { get; set; }
        public BasicInformation basic_information { get; set; }
        public int id { get; set; }
    }
}
