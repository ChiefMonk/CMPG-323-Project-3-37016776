using System;
using System.Collections.Generic;
using System.Linq;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.WebAPP.Models.Converters
{
	internal static class DeviceConverters
	{
		#region ToModel

		/// <summary>
		/// Converts to model device.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		internal static ModelDevice ToModelDevice(this EntityDevice entity)
		{
			if (entity == null)
				return null;

			return new ModelDevice
			{
				DeviceId = entity.Id,
				DeviceName = entity.DeviceName,
				CategoryId = entity.CategoryId,
				ZoneId = entity.ZoneId,
				Status = entity.Status,
				IsActive = entity.IsActive,
				DateCreated = entity.DateCreated,
				ModelCategory = entity.Category?.ToModelCategory(),
				ModelZone = entity.Zone?.ToModelZone()
			};
		}

		/// <summary>
		/// Converts to model device collection.
		/// </summary>
		/// <param name="entityList">The entity list.</param>
		/// <returns></returns>
		internal static IList<ModelDevice> ToModelDeviceCollection(this IEnumerable<EntityDevice> entityList)
		{
			var dtoList = new List<ModelDevice>();

			if (entityList == null || !entityList.Any())
				return dtoList;

			foreach (var entity in entityList)
			{
				var dto = entity.ToModelDevice();
				if (dto != null)
					dtoList.Add(dto);
			}

			return dtoList;
		}

		#endregion

		#region ToEntity

		/// <summary>
		/// Converts to entity device.
		/// </summary>
		/// <param name="dto">The dto.</param>
		/// <param name="isCreate">if set to <c>true</c> [is create].</param>
		/// <returns></returns>
		internal static EntityDevice ToEntityDevice(this ModelDevice dto, bool isCreate = false)
		{
			if (dto == null)
				return null;

			if (dto.DeviceId == Guid.Empty)
				dto.DeviceId = Guid.NewGuid();

			if (isCreate)
				dto.DateCreated = DateTime.UtcNow.AddHours(2);

			return new EntityDevice
			{
				Id = dto.DeviceId,
				DeviceName = dto.DeviceName,
				CategoryId = dto.CategoryId,
				ZoneId = dto.ZoneId,
				Status = dto.Status,
				IsActive = dto.IsActive,
				DateCreated = dto.DateCreated,
			};
		}

		#endregion
	}
}
