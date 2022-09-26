using System;
using System.Collections.Generic;
using System.Linq;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.WebAPP.Models.Converters
{
	internal static class CategoryConverters
	{
		#region ToModel

		/// <summary>
		/// Converts to model category.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
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

		/// <summary>
		/// Converts to model category collection.
		/// </summary>
		/// <param name="entityList">The entity list.</param>
		/// <returns></returns>
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

		/// <summary>
		/// Converts to entity category.
		/// </summary>
		/// <param name="dto">The dto.</param>
		/// <param name="isCreate">if set to <c>true</c> [is create].</param>
		/// <returns></returns>
		internal static EntityCategory ToEntityCategory(this ModelCategory dto, bool isCreate = false)
		{
			if (dto == null)
				return null;

			if (dto.CategoryId == Guid.Empty)
				dto.CategoryId = Guid.NewGuid();
			
			if (isCreate)
				dto.DateCreated = DateTime.UtcNow.AddHours(2);

			return new EntityCategory
			{
				Id = dto.CategoryId,
				CategoryName = dto.CategoryName,
				CategoryDescription = dto.CategoryDescription,
				DateCreated = dto.DateCreated,
			};
		}

		#endregion
	}
}
