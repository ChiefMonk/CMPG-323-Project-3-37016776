using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project3.DeviceManagement.Data.Entities
{
	/// <summary>
	/// 
	/// </summary>
	[Table("Category")]
	public class EntityCategory
	{
		/// <summary>
		/// Gets or sets the category identifier.
		/// </summary>
		/// <value>
		/// The category identifier.
		/// </value>
		[Key]
		public Guid CategoryId { get; set; }

		/// <summary>
		/// Gets or sets the name of the category.
		/// </summary>
		/// <value>
		/// The name of the category.
		/// </value>
		public string CategoryName { get; set; }

		/// <summary>
		/// Gets or sets the category description.
		/// </summary>
		/// <value>
		/// The category description.
		/// </value>
		public string CategoryDescription { get; set; }

		/// <summary>
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		public DateTime DateCreated { get; set; }
	}
}
