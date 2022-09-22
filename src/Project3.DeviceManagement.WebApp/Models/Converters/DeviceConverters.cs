using System;
using System.Collections.Generic;
using System.Linq;
using Project3.DeviceManagement.Data.Entities;
using Project3.DeviceManagement.WebAPP.Models;

namespace Project2.WebAPI.DAL.Converters
{
    internal static class DeviceConverters
    {
        #region ToDto

        internal static Device ToDtoDevice(this EntityDevice entity)
        {
	        if (entity == null)
		        return null;

	        return new Device
	        {
		        DeviceId = entity.Id,
		        DeviceName = entity.DeviceName,
		        CategoryId = entity.CategoryId,
		        ZoneId = entity.ZoneId,
		        Status = entity.Status,
		        IsActive = entity.IsActive,
		        DateCreated = entity.DateCreated,
	        };
        }

        internal static IList<Device> ToDtoDeviceCollection(this IEnumerable<EntityDevice> entityList)
        {
            var dtoList = new List<Device>();

            if (entityList == null || !entityList.Any())
                return dtoList;

            foreach (var entity in entityList)
            {
                var dto = entity.ToDtoDevice();
                if (dto != null)
                    dtoList.Add(dto);
            }

            return dtoList;
        }

        #endregion

        #region ToEntity

        internal static EntityDevice ToEntityDevice(this Device dto)
        {
            if (dto == null)
                return null;

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

        internal static EntityDevice ToEntityDevice(this Device dto, EntityDevice currentEntity)
        {
            if (dto == null)
                return null;

            currentEntity.DeviceName = dto.DeviceName;

            if (dto.CategoryId != Guid.NewGuid())
                currentEntity.CategoryId = dto.CategoryId;

            if (dto.ZoneId != Guid.NewGuid())
                currentEntity.ZoneId = dto.ZoneId;

            currentEntity.Status = dto.Status;
            currentEntity.IsActive = dto.IsActive;

            return currentEntity;
        }

        #endregion
    }
}
