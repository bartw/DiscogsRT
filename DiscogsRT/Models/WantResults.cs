using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class WantResults
    {
        public Pagination pagination { get; set; }
        public List<Want> wants { get; set; }
    }
}
