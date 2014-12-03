using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Developer
    {
        public Developer()
        {
            this.Softwares = new List<Software>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public virtual ICollection<Software> Softwares { get; set; }
    }
}
