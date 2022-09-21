using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.Data.Repositories.Category
{
    public interface ICategoryRepository : IRepository
    {
	    ValueTask<IList<EntityCategory>> GetAllCategoryCollectionAsync();

	    ValueTask<EntityCategory> GetCategoryByIdAsync(Guid id);

	    ValueTask<int> GetNumberOfZonesByCategoryIdAsync(Guid id);

	    ValueTask<Guid> CreateCategoryAsync(EntityCategory entity);

	    ValueTask<Guid> UpdateCategoryAsync(EntityCategory entity);

	    ValueTask<Guid> DeleteCategory(Guid id);

	    ValueTask<bool> DoesCategoryExistAsync(Guid id);
	}
}