using System;
using System.Collections.Generic;
using System.Linq;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.WebAPP.Models.Converters
{
	internal static class ZoneConverters
	{
		#region ToModel

		/// <summary>
		/// Converts to model zone.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		internal static ModelZone ToModelZone(this EntityZone entity)
		{
			if (entity == null)
				return null;

			return new ModelZone
			{
				ZoneId = entity.Id,
				ZoneName = entity.ZoneName,
				ZoneDescription = entity.ZoneDescription,
				DateCreated = entity.DateCreated,
			};
		}

		/// <summary>
		/// Converts to model zone collection.
		/// </summary>
		/// <param name="entityList">The entity list.</param>
		/// <returns></returns>
		internal static IList<ModelZone> ToModelZoneCollection(this IEnumerable<EntityZone> entityList)
		{
			var dtoList = new List<ModelZone>();

			if (entityList == null || !entityList.Any())
				return dtoList;

			foreach (var entity in entityList)
			{
				var dto = entity.ToModelZone();
				if (dto != null)
					dtoList.Add(dto);
			}

			return dtoList;
		}

		#endregion

		#region ToEntity

		/// <summary>
		/// Converts to entity zone.
		/// </summary>
		/// <param name="dto">The dto.</param>
		/// <param name="isCreate">if set to <c>true</c> [is create].</param>
		/// <returns></returns>
		internal static EntityZone ToEntityZone(this ModelZone dto, bool isCreate = false)
		{
			if (dto == null)
				return null;

			if (dto.ZoneId == Guid.Empty)
				dto.ZoneId = Guid.NewGuid();

			if (isCreate)
				dto.DateCreated = DateTime.UtcNow.AddHours(2);

			return new EntityZone
			{
				Id = dto.ZoneId,
				ZoneName = dto.ZoneName,
				ZoneDescription = dto.ZoneDescription,
				DateCreated = dto.DateCreated,
			};
		}

		#endregion
	}
}
