using Project3.DeviceManagement.Data.Repositories.Device;
using Project3.DeviceManagement.WebAPP.Data;

namespace Project3.DeviceManagement.Data.Repositories.Category
{
	public class DeviceRepository : RepositoryBase, IDeviceRepository
	{
		public DeviceRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}
	}
}