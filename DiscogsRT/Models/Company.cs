﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class Company
    {
        public string name { get; set; }
        public string entity_type { get; set; }
        public string catno { get; set; }
        public string resource_url { get; set; }
        public int id { get; set; }
        public string entity_type_name { get; set; }
    }
}
