using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3.DeviceManagement.WebAPP.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Project3.DeviceManagement.Data.Entities;
using System.Net;

namespace Project3.DeviceManagement.Data.Repositories.Category
{
	public class CategoryRepository : RepositoryBase, ICategoryRepository
	{
		private const string ErrorInvalidCategoryId = "Please specify a valid category-id";
		private const string ErrorCategoryNotExit = "This category does not exist";

		public CategoryRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}

		public async ValueTask<IList<EntityCategory>> GetAllCategoryCollectionAsync()
		{
			return await _officeDbContext.Category.AsNoTracking().ToListAsync();
		}

		public async ValueTask<EntityCategory> GetCategoryByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public async ValueTask<int> GetNumberOfZonesByCategoryIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public async ValueTask<Guid> CreateCategoryAsync(EntityCategory entity)
		{
			throw new NotImplementedException();
		}

		public async ValueTask<Guid> UpdateCategoryAsync(EntityCategory entity)
		{
			throw new NotImplementedException();
		}

		public async ValueTask<Guid> DeleteCategory(Guid id)
		{
			try
			{
				var exists = await DoesCategoryExistAsync(id);
				if (!exists)
					return BadRequest(ErrorCategoryNotExit);

				//check if category has devices assigned
				var hasDevices = await _officeDbContext.Device.AsTracking().AnyAsync(e => e.CategoryId == id);
				if (hasDevices)
				{
					throw new MyWebApiException(HttpStatusCode.Forbidden,
						"You can not delete this category because it has devices assigned to it");
				}

				var entity = await _officeDbContext.Category.AsTracking().FirstOrDefaultAsync(e => e.CategoryId == id);

				if (entity != null)
				{
					_officeDbContext.Category.Remove(entity);
					await _officeDbContext.SaveChangesAsync();
				}

				return StatusCode(StatusCodes.Status204NoContent, "The category has been deleted successfully");
			}
			catch (MyWebApiException ex)
			{
				return StatusCode((int)ex.StatusCode, ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		public async ValueTask<bool> DoesCategoryExistAsync(Guid id)
		{
			return await _officeDbContext.Category.AsTracking().AnyAsync(e => e.CategoryId == id);
		}
	}
}