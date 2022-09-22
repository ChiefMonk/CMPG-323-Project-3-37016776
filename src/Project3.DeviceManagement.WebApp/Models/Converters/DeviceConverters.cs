using System;
using System.Collections.Generic;
using System.Linq;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.WebAPP.Models.Converters
{
    internal static class DeviceConverters
    {
		#region ToModel

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

        internal static EntityDevice ToEntityDevice(this ModelDevice dto)
        {
	        if (dto == null)
		        return null;

	        if (dto.DeviceId == Guid.Empty)
	        {
		        dto.DeviceId = Guid.NewGuid();
		        dto.DateCreated = DateTime.Now;
	        }

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

        internal static EntityDevice ToEntityDevice(this ModelDevice dto, EntityDevice currentEntity)
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
