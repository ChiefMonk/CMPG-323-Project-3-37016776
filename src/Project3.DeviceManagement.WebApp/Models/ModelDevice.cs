using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project3.DeviceManagement.WebAPP.Models
{
	/// <summary>
	/// ModelDevice
	/// </summary>
	public class ModelDevice
	{
		/// <summary>
		/// Gets or sets the device identifier.
		/// </summary>
		/// <value>
		/// The device identifier.
		/// </value>
		[DisplayName("Device ID")]
		public Guid DeviceId { get; set; }

		/// <summary>
		/// Gets or sets the name of the device.
		/// </summary>
		/// <value>
		/// The name of the device.
		/// </value>
		[DisplayName("Device Name")]
		public string DeviceName { get; set; }

		/// <summary>
		/// Gets or sets the category identifier.
		/// </summary>
		/// <value>
		/// The category identifier.
		/// </value>
		[DisplayName("Category ID")]
		public Guid CategoryId { get; set; }

		/// <summary>
		/// Gets or sets the zone identifier.
		/// </summary>
		/// <value>
		/// The zone identifier.
		/// </value>
		[DisplayName("Zone ID")]
		public Guid ZoneId { get; set; }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		[DisplayName("Status")]
		public string Status { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is active.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
		/// </value>
		[DisplayName("Is Active")]
		public bool IsActive { get; set; }

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
		/// Gets or sets the model category.
		/// </summary>
		/// <value>
		/// The model category.
		/// </value>
		[DisplayName("Category")]
		public ModelCategory ModelCategory { get; set; }

		/// <summary>
		/// Gets or sets the model zone.
		/// </summary>
		/// <value>
		/// The model zone.
		/// </value>
		[DisplayName("Zone")]
		public ModelZone ModelZone { get; set; }
	}
}
