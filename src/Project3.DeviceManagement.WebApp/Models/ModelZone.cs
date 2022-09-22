using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project3.DeviceManagement.WebAPP.Models
{
    public class ModelZone
    {
        public ModelZone()
        {
            Device = new HashSet<ModelDevice>();
        }

        [DisplayName("Zone ID")]
        public Guid ZoneId { get; set; }

        [DisplayName("Zone Name")]
        public string ZoneName { get; set; }

        [DisplayName("Zone Description")]
        public string ZoneDescription { get; set; }

        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Device")]
        public ICollection<ModelDevice> Device { get; set; }
    }
}
