using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Tracklist
    {
        public string duration { get; set; }
        public string position { get; set; }
        public string type_ { get; set; }
        public string title { get; set; }
        public List<Extraartist> extraartists { get; set; }
    }
}
