using Project3.DeviceManagement.Data.Repositories.Device;
using Project3.DeviceManagement.Data.Repositories.User;

namespace Project3.DeviceManagement.WebAPI.Services.User
{
	public class SystemUserService : ServiceBase, ISystemUserService
	{
		private readonly ISystemUserRepository _systemUserRepository;

		public SystemUserService(ISystemUserRepository systemUserRepository)
		{
			_systemUserRepository = systemUserRepository;
		}
	}
}