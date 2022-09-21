using Project3.DeviceManagement.Data.Repositories.Device;
using Project3.DeviceManagement.WebAPP.Data;

namespace Project3.DeviceManagement.Data.Repositories.Category
{
	public class ZoneRepository : RepositoryBase, IZoneRepository
	{
		public ZoneRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}
	}
}