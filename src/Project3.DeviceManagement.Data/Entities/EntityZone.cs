using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Project3.DeviceManagement.Data.Entities
{

	[Table("Zone")]
	public partial class EntityZone : IDataEntity
	{
		public EntityZone()
		{
			Device = new HashSet<EntityDevice>();
		}

		[Key]
		[Column("ZoneId")]
		public Guid Id { get; set; }

		public string ZoneName { get; set; }

		public string ZoneDescription { get; set; }

		public DateTime DateCreated { get; set; }

		public virtual ICollection<EntityDevice> Device { get; set; }
	}
}
