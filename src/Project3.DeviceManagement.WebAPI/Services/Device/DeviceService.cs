using Project3.DeviceManagement.Data.Repositories.Device;

namespace Project3.DeviceManagement.WebAPI.Services.Device
{
	public class DeviceService : ServiceBase, IDeviceService
	{
		private readonly IDeviceRepository _deviceRepository;

		public DeviceService(IDeviceRepository deviceRepository)
		{
			_deviceRepository = deviceRepository;
		}
	}
}