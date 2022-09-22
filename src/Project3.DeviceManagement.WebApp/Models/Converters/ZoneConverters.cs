using System;
using System.Collections.Generic;
using System.Linq;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.WebAPP.Models.Converters
{
    internal static class ZoneConverters
    {
		#region ToModel

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

        internal static EntityZone ToEntityZone(this ModelZone dto)
        {
	        if (dto == null)
		        return null;

	        if (dto.ZoneId == Guid.Empty)
	        {
		        dto.ZoneId = Guid.NewGuid();
		        dto.DateCreated = DateTime.Now;
	        }

	        return new EntityZone
	        {
		        Id = dto.ZoneId,
		        ZoneName = dto.ZoneName,
		        ZoneDescription = dto.ZoneDescription,
		        DateCreated = dto.DateCreated,
	        };
        }

        internal static EntityZone ToEntityZone(this ModelZone dto, EntityZone currentEntity)
        {
            if (dto == null)
                return null;

            currentEntity.ZoneName = dto.ZoneName;
            currentEntity.ZoneDescription = dto.ZoneDescription;

            return currentEntity;
        }

        #endregion
    }
}
