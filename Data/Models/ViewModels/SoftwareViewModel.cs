using System;
using System.Collections.Generic;

namespace Data.Models.ViewModels
{
    public class SoftwareViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int dev_id { get; set; }
        public string developerName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public virtual Developer developer { get; set; }
    }
}
