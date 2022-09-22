using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Project3.DeviceManagement.Data.Entities
{
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
	public class EntitySystemUser : IdentityUser, IDataEntity
	{
		[Key]
		public new Guid Id {
			get => Guid.Parse(base.Id);
			set => base.Id = value.ToString();
		}
	}
}
