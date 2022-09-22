using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Project3.DeviceManagement.Data.Entities
{
	[Table("Category")]
	public partial class EntityCategory : IDataEntity
	{
		public EntityCategory()
		{
			Device = new HashSet<EntityDevice>();
		}

		[Key]
		[Column("CategoryId")]
		public Guid Id { get; set; }

		public string CategoryName { get; set; }

		public string CategoryDescription { get; set; }

		public DateTime DateCreated { get; set; }

		public virtual ICollection<EntityDevice> Device { get; set; }
	}
}
