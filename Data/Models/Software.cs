using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Software
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int dev_id { get; set; }
        public Nullable<decimal> Price { get; set; }
        public virtual Developer developer { get; set; }
    }
}
