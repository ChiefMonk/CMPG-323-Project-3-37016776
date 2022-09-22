using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project3.DeviceManagement.Data.Entities
{
	/// <summary>
	/// 
	/// </summary>
	[Table("Zone")]
	public class EntityZone : IDataEntity
	{
		/// <summary>
		/// Gets or sets the zone identifier.
		/// </summary>
		/// <value>
		/// The zone identifier.
		/// </value>
		[Key]
		[Column("ZoneId")]
		public Guid Id { get; set; }
		/// <summary>
		/// Gets or sets the name of the zone.
		/// </summary>
		/// <value>
		/// The name of the zone.
		/// </value>
		public string ZoneName { get; set; }
		/// <summary>
		/// Gets or sets the zone description.
		/// </summary>
		/// <value>
		/// The zone description.
		/// </value>
		public string ZoneDescription { get; set; }
		/// <summary>
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		public DateTime DateCreated { get; set; }
	}
}
