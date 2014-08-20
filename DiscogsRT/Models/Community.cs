using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Community
    {
        public string status { get; set; }
        public Rating rating { get; set; }
        public int have { get; set; }
        public List<Contributor> contributors { get; set; }
        public int want { get; set; }
        public Submitter submitter { get; set; }
        public string data_quality { get; set; }
    }
}
