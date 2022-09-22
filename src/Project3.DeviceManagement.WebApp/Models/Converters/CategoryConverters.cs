using System;
using System.Collections.Generic;
using System.Linq;
using Project3.DeviceManagement.Data.Entities;
using Project3.DeviceManagement.WebAPP.Models;

namespace Project2.WebAPI.DAL.Converters
{
    internal static class CategoryConverters
    {
        #region ToDto

        internal static Category ToDtoCategory(this EntityCategory entity)
        {
            if (entity == null)
                return null;

            return new Category
						{
                CategoryId = entity.Id,
                CategoryName = entity.CategoryName,
                CategoryDescription = entity.CategoryDescription,
                DateCreated = entity.DateCreated,
            };
        }

        internal static IList<Category> ToDtoCategoryCollection(this IEnumerable<EntityCategory> entityList)
        {
            var dtoList = new List<Category>();

            if (entityList == null || !entityList.Any())
                return dtoList;

            foreach (var entity in entityList)
            {
                var dto = entity.ToDtoCategory();
                if (dto != null)
                    dtoList.Add(dto);
            }

            return dtoList;
        }

        #endregion

        #region ToEntity

        internal static EntityCategory ToEntityCategory(this Category dto)
        {
	        if (dto == null)
		        return null;

	        if (dto.CategoryId == Guid.Empty)
		        dto.CategoryId = Guid.NewGuid();

	        return new EntityCategory
	        {
		        Id = dto.CategoryId,
		        CategoryName = dto.CategoryName,
		        CategoryDescription = dto.CategoryDescription,
		        DateCreated = dto.DateCreated,
	        };
        }

        internal static EntityCategory ToEntityCategory(this Category dto, EntityCategory currentEntity)
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
