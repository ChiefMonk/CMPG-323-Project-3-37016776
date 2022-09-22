using Project3.DeviceManagement.Data.Db;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.Data.Repositories.Device
{
	public class DeviceRepository : Repository<EntityDevice>, IDeviceRepository
	{
		public DeviceRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}
	}
}