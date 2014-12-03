using System;
using System.Collections.Generic;

namespace Data.Models.ViewModels
{
    public class DeveloperViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string SoftwareName { get; set; }
        public virtual ICollection<Software> Softwares { get; set; }
    }
}
