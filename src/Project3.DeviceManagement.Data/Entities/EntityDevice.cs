using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project3.DeviceManagement.Data.Entities
{
	/// <summary>
	/// 
	/// </summary>
	[Table("Device")]
	public class EntityDevice : IDataEntity
	{
		/// <summary>
		/// Gets or sets the device identifier.
		/// </summary>
		/// <value>
		/// The device identifier.
		/// </value>
		[Key]
		[Column("DeviceId")]
		public Guid Id { get; set; }
		/// <summary>
		/// Gets or sets the name of the device.
		/// </summary>
		/// <value>
		/// The name of the device.
		/// </value>
		public string DeviceName { get; set; }
		/// <summary>
		/// Gets or sets the category identifier.
		/// </summary>
		/// <value>
		/// The category identifier.
		/// </value>
		[ForeignKey("Category")]
		public Guid CategoryId { get; set; }
		/// <summary>
		/// Gets or sets the zone identifier.
		/// </summary>
		/// <value>
		/// The zone identifier.
		/// </value>
		[ForeignKey("Zone")]
		public Guid ZoneId { get; set; }
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		public string Status { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is active.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
		/// </value>
		public bool IsActive { get; set; }
		/// <summary>
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		public DateTime DateCreated { get; set; }

		/// <summary>
		/// Gets or sets the category.
		/// </summary>
		/// <value>
		/// The category.
		/// </value>
		public EntityCategory Category { get; set; }

		/// <summary>
		/// Gets or sets the zone.
		/// </summary>
		/// <value>
		/// The zone.
		/// </value>
		public EntityZone Zone { get; set; }
	}
}
