using Project3.DeviceManagement.Data.Db;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.Data.Repositories.Zone
{
	public class ZoneRepository : Repository<EntityZone>, IZoneRepository
	{
		public ZoneRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}
	}
}