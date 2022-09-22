using System;
using System.Threading.Tasks;
using Project3.DeviceManagement.Data.Repositories.Category;
using Project3.DeviceManagement.Data.Repositories.Device;
using Project3.DeviceManagement.Data.Repositories.Zone;

namespace Project3.DeviceManagement.Data.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		ICategoryRepository Categories { get; }
		IDeviceRepository Devices { get; }
		IZoneRepository Zones { get; }
		ValueTask<int> CompleteAsync();
	}
}