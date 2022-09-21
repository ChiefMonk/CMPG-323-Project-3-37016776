using Project3.DeviceManagement.Data.Repositories.Device;

namespace Project3.DeviceManagement.WebAPI.Services.Zone
{
	public class ZoneService : ServiceBase, IZoneService
	{
		private readonly IZoneRepository _zoneRepository;

		public ZoneService(IZoneRepository zoneRepository)
		{
			_zoneRepository = zoneRepository;
		}
	}
}