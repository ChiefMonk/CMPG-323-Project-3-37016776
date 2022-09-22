using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project3.DeviceManagement.WebAPP.Models
{
    public class ModelCategory
    {
        public ModelCategory()
        {
            Device = new HashSet<ModelDevice>();
        }

        [DisplayName("Category ID")]
        public Guid CategoryId { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Category Description")]
        public string CategoryDescription { get; set; }
        [DisplayName("Category Date Created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Device")]
        public ICollection<ModelDevice> Device { get; set; }
    }
}
