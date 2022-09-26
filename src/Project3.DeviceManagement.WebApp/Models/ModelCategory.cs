using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project3.DeviceManagement.WebAPP.Models
{
	/// <summary>
	/// ModelCategory
	/// </summary>
	public class ModelCategory
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ModelCategory"/> class.
		/// </summary>
		public ModelCategory()
		{
			Device = new HashSet<ModelDevice>();
		}

		/// <summary>
		/// Gets or sets the category identifier.
		/// </summary>
		/// <value>
		/// The category identifier.
		/// </value>
		[DisplayName("Category ID")]
		public Guid CategoryId { get; set; }

		/// <summary>
		/// Gets or sets the name of the category.
		/// </summary>
		/// <value>
		/// The name of the category.
		/// </value>
		[DisplayName("Category Name")]
		public string CategoryName { get; set; }

		/// <summary>
		/// Gets or sets the category description.
		/// </summary>
		/// <value>
		/// The category description.
		/// </value>
		[DisplayName("Category Description")]
		public string CategoryDescription { get; set; }

		/// <summary>
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		[DisplayName("Category Date Created")]
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
