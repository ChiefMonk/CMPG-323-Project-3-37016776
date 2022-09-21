using Project3.DeviceManagement.Data.Repositories.Device;
using Project3.DeviceManagement.WebAPP.Data;

namespace Project3.DeviceManagement.Data.Repositories.Category
{
	public class SystemUserRepository : RepositoryBase, ISystemUserRepository
	{
		public SystemUserRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}
	}
}