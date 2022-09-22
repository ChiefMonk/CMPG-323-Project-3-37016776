using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.DeviceManagement.Data.Entities
{
	/// <summary>
	/// 
	/// </summary>
	[Table("UserSession")]
	public class EntityUserSession : IDataEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EntityUserSession"/> class.
		/// </summary>
		public EntityUserSession()
		{
			DateCreated = DateTime.UtcNow;
			LogoutDate = null;
		}
		/// <summary>
		/// Gets or sets the session identifier.
		/// </summary>
		/// <value>
		/// The session identifier.
		/// </value>
		[Key]
		[Column("SessionId")]
		public Guid Id { get; set; }
		/// <summary>
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// Gets or sets the logout date.
		/// </summary>
		/// <value>
		/// The logout date.
		/// </value>
		public DateTime? LogoutDate { get; set; }
	}
}