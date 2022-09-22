using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Project3.DeviceManagement.Data.Entities
{
	[Table("Device")]
	public partial class EntityDevice : IDataEntity
	{
		[Key]
		[Column("DeviceId")]
		public Guid Id { get; set; }
		
		public string DeviceName { get; set; }
	
		[ForeignKey("Category")]
		public Guid CategoryId { get; set; }
	
		[ForeignKey("Zone")]
		public Guid ZoneId { get; set; }
		
		public string Status { get; set; }

		
		public bool IsActive { get; set; }
		
		public DateTime DateCreated { get; set; }

		public virtual EntityCategory Category { get; set; }

		public virtual EntityZone Zone { get; set; }
	}
}
