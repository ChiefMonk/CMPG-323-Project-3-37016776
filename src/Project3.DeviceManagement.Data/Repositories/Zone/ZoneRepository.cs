using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Project3.DeviceManagement.Data.Db;
using Project3.DeviceManagement.Data.Entities;
using Project3.DeviceManagement.Data.Exceptions;
using System.Threading.Tasks;
using System;

namespace Project3.DeviceManagement.Data.Repositories.Zone
{
	/// <summary>
	/// ZoneRepository
	/// </summary>
	/// <seealso cref="Project3.DeviceManagement.Data.Repositories.Repository&lt;Project3.DeviceManagement.Data.Entities.EntityZone&gt;" />
	/// <seealso cref="Project3.DeviceManagement.Data.Repositories.Zone.IZoneRepository" />
	public class ZoneRepository : Repository<EntityZone>, IZoneRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ZoneRepository"/> class.
		/// </summary>
		/// <param name="dbContext"></param>
		public ZoneRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		/// <exception cref="Project3.DeviceManagement.Data.Exceptions.MyWebApiException">You can not delete this zone because it has devices assigned to it</exception>
		public override async ValueTask<Guid> RemoveAsync(Guid id)
		{
			var hasDevices = await _officeDbContext.Set<EntityDevice>().AsTracking().AnyAsync(e => e.CategoryId == id);

			if (hasDevices)
			{
				throw new MyWebApiException(StatusCodes.Status403Forbidden,
					"You can not delete this zone because it has devices assigned to it");
			}

			return await base.RemoveAsync(id);
		}
	}
}