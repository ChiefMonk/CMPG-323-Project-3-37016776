﻿using System;

namespace Project3.DeviceManagement.Shared.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	public interface IDto
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		Guid Id { get; set; }
		/// <summary>
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		DateTime DateCreated { get; set; }
	}
}