using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project3.DeviceManagement.WebAPP.Models
{
	/// <summary>
	/// ModelZone
	/// </summary>
	public class ModelZone
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ModelZone"/> class.
		/// </summary>
		public ModelZone()
		{
			Device = new HashSet<ModelDevice>();
		}

		/// <summary>
		/// Gets or sets the zone identifier.
		/// </summary>
		/// <value>
		/// The zone identifier.
		/// </value>
		[DisplayName("Zone ID")]
		public Guid ZoneId { get; set; }

		/// <summary>
		/// Gets or sets the name of the zone.
		/// </summary>
		/// <value>
		/// The name of the zone.
		/// </value>
		[DisplayName("Zone Name")]
		public string ZoneName { get; set; }

		/// <summary>
		/// Gets or sets the zone description.
		/// </summary>
		/// <value>
		/// The zone description.
		/// </value>
		[DisplayName("Zone Description")]
		public string ZoneDescription { get; set; }

		/// <summary>
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		[DisplayName("Date Created")]
		[DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
		public DateTime DateCreated { get; set; }

		/// <summary>
		/// Gets or sets the device.
		/// </summary>
		/// <value>
		/// The device.
		/// </value>
		[DisplayName("Device")]
		public ICollection<ModelDevice> Device { get; set; }
	}
}
