using Project3.DeviceManagement.Data.Db;
using Project3.DeviceManagement.Data.Entities;

namespace Project3.DeviceManagement.Data.Repositories.Device
{
	/// <summary>
	/// DeviceRepository
	/// </summary>
	/// <seealso cref="Project3.DeviceManagement.Data.Repositories.Repository&lt;Project3.DeviceManagement.Data.Entities.EntityDevice&gt;" />
	/// <seealso cref="Project3.DeviceManagement.Data.Repositories.Device.IDeviceRepository" />
	public class DeviceRepository : Repository<EntityDevice>, IDeviceRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DeviceRepository"/> class.
		/// </summary>
		/// <param name="dbContext"></param>
		public DeviceRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}
	}
}