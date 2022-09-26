using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Project3.DeviceManagement.Data.Entities;
using Project3.DeviceManagement.Data.Db;
using Project3.DeviceManagement.Data.Exceptions;

namespace Project3.DeviceManagement.Data.Repositories.Category
{
	/// <summary>
	/// CategoryRepository
	/// </summary>
	/// <seealso cref="Project3.DeviceManagement.Data.Repositories.Repository&lt;Project3.DeviceManagement.Data.Entities.EntityCategory&gt;" />
	/// <seealso cref="Project3.DeviceManagement.Data.Repositories.Category.ICategoryRepository" />
	public class CategoryRepository : Repository<EntityCategory>, ICategoryRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryRepository"/> class.
		/// </summary>
		/// <param name="dbContext"></param>
		public CategoryRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		/// <exception cref="Project3.DeviceManagement.Data.Exceptions.MyWebApiException">You can not delete this category because it has devices assigned to it</exception>
		public override async ValueTask<Guid> RemoveAsync(Guid id)
		{
			var hasDevices = await _officeDbContext.Set<EntityDevice>().AsTracking().AnyAsync(e => e.CategoryId == id);

			if (hasDevices)
			{
				throw new MyWebApiException(StatusCodes.Status403Forbidden,
					"You can not delete this category because it has devices assigned to it");
			}

			return await base.RemoveAsync(id);
		}
	}
}