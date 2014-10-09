using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class CollectionResults
    {
        public Pagination pagination { get; set; }
        public List<CollectionItem> releases { get; set; }
    }
}
