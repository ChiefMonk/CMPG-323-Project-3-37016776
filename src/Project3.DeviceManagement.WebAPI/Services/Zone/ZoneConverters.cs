﻿using System.Collections.Generic;
using System.Linq;
using Project2.WebAPI.DAL.Dtos;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.WebAPI.Services.Zone
{
    internal static class ZoneConverters
    {
        #region ToDto

        internal static DtoZone ToDtoZone(this EntityZone entity)
        {
            if (entity == null)
                return null;

            return new DtoZone
            {
                Id = entity.ZoneId,
                ZoneName = entity.ZoneName,
                ZoneDescription = entity.ZoneDescription,
                DateCreated = entity.DateCreated,
            };
        }

        internal static IList<DtoZone> ToDtoZoneCollection(this IList<EntityZone> entityList)
        {
            var dtoList = new List<DtoZone>();

            if (entityList == null || !entityList.Any())
                return dtoList;

            foreach (var entity in entityList)
            {
                var dto = entity.ToDtoZone();
                if (dto != null)
                    dtoList.Add(dto);
            }

            return dtoList;
        }

        #endregion

        #region ToEntity

        internal static EntityZone ToEntityZone(this DtoZone dto)
        {
            if (dto == null)
                return null;

            return new EntityZone
            {
                ZoneId = dto.Id,
                ZoneName = dto.ZoneName,
                ZoneDescription = dto.ZoneDescription,
                DateCreated = dto.DateCreated,
            };
        }

        internal static EntityZone ToEntityZone(this DtoZone dto, EntityZone currentEntity)
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
