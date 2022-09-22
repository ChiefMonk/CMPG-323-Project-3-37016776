using System;
using System.Collections.Generic;
using System.Linq;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.WebAPP.Models.Converters
{
    internal static class CategoryConverters
    {
		#region ToModel

		internal static ModelCategory ToModelCategory(this EntityCategory entity)
        {
            if (entity == null)
                return null;

            return new ModelCategory
						{
                CategoryId = entity.Id,
                CategoryName = entity.CategoryName,
                CategoryDescription = entity.CategoryDescription,
                DateCreated = entity.DateCreated,
            };
        }

        internal static IList<ModelCategory> ToModelCategoryCollection(this IEnumerable<EntityCategory> entityList)
        {
            var dtoList = new List<ModelCategory>();

            if (entityList == null || !entityList.Any())
                return dtoList;

            foreach (var entity in entityList)
            {
                var dto = entity.ToModelCategory();
                if (dto != null)
                    dtoList.Add(dto);
            }

            return dtoList;
        }

        #endregion

        #region ToEntity

        internal static EntityCategory ToEntityCategory(this ModelCategory dto)
        {
	        if (dto == null)
		        return null;

	        if (dto.CategoryId == Guid.Empty)
	        {
		        dto.CategoryId = Guid.NewGuid();
		        dto.DateCreated = DateTime.Now;
	        }

	        return new EntityCategory
	        {
		        Id = dto.CategoryId,
		        CategoryName = dto.CategoryName,
		        CategoryDescription = dto.CategoryDescription,
		        DateCreated = dto.DateCreated,
	        };
        }

        internal static EntityCategory ToEntityCategory(this ModelCategory dto, EntityCategory currentEntity)
        {
            if (dto == null)
                return null;

            currentEntity.CategoryName = dto.CategoryName;
            currentEntity.CategoryDescription = dto.CategoryDescription;

            return currentEntity;
        }

        #endregion
    }
}
