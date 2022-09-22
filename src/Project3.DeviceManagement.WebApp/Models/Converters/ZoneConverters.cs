using System.Collections.Generic;
using System.Linq;
using Project3.DeviceManagement.Data.Entities;
using Project3.DeviceManagement.WebAPP.Models;

namespace Project2.WebAPI.DAL.Converters
{
    internal static class ZoneConverters
    {
        #region ToDto

        internal static Zone ToModelZone(this EntityZone entity)
        {
            if (entity == null)
                return null;

            return new Zone
						{
							ZoneId = entity.Id,
                ZoneName = entity.ZoneName,
                ZoneDescription = entity.ZoneDescription,
                DateCreated = entity.DateCreated,
            };
        }

        internal static IList<Zone> ToModelZoneCollection(this List<EntityZone> entityList)
        {
            var dtoList = new List<Zone>();

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

        internal static EntityZone ToEntityZone(this Zone dto)
        {
            if (dto == null)
                return null;

            return new EntityZone
            {
                Id = dto.ZoneId,
                ZoneName = dto.ZoneName,
                ZoneDescription = dto.ZoneDescription,
                DateCreated = dto.DateCreated,
            };
        }

        internal static EntityZone ToEntityZone(this Zone dto, EntityZone currentEntity)
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
