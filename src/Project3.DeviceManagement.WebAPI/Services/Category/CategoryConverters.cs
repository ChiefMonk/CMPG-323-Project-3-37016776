﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using Project2.WebAPI.DAL.Dtos;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.WebAPI.Services.Category
{
  internal static class CategoryConverters
  {
		#region ToDto

		internal static DtoCategory ToDtoCategory(this EntityCategory entity)
		{
			if (entity == null)
				return null;

			return new DtoCategory
			{
				Id = entity.CategoryId,
				CategoryName = entity.CategoryName,
				CategoryDescription = entity.CategoryDescription,
				DateCreated = entity.DateCreated,
			};
		}

		internal static IList<DtoCategory> ToDtoCategoryCollection(this IList<EntityCategory> entityList)
		{
			var dtoList = new List<DtoCategory>();

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

		internal static EntityCategory ToEntityCategory(this DtoCategory dto)
		{
			if (dto == null)
				return null;

			return new EntityCategory
			{
				CategoryId = dto.Id,
				CategoryName = dto.CategoryName,
				CategoryDescription = dto.CategoryDescription,
				DateCreated = dto.DateCreated,
			};
		}

		internal static EntityCategory ToEntityCategory(this DtoCategory dto, EntityCategory currentEntity)
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
