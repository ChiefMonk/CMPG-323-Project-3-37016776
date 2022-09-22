using System;
using System.ComponentModel;

namespace Project3.DeviceManagement.WebAPP.Models
{
    public class ModelDevice
    {
        [DisplayName("Device ID")]
        public Guid DeviceId { get; set; }
        [DisplayName("Device Name")]
        public string DeviceName { get; set; }
        [DisplayName("Category ID")]
        public Guid CategoryId { get; set; }
        [DisplayName("Zone ID")]
        public Guid ZoneId { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Category")]
        public ModelCategory ModelCategory { get; set; }
        [DisplayName("Zone")]
        public ModelZone ModelZone { get; set; }
    }
}
