using System;
using System.Threading.Tasks;
using Project3.DeviceManagement.Data.Db;
using Project3.DeviceManagement.Data.Repositories.Category;
using Project3.DeviceManagement.Data.Repositories.Device;
using Project3.DeviceManagement.Data.Repositories.Zone;

namespace Project3.DeviceManagement.Data.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ConnectedOfficeDbContext _officeDbContext;

		protected UnitOfWork(ConnectedOfficeDbContext officeDbContext,
			ICategoryRepository categories,
			IDeviceRepository devices,
			IZoneRepository zones)
		{
			_officeDbContext = officeDbContext;
			Categories = categories;
			Devices = devices;
			Zones = zones;
		}

		#region Repositories
		public ICategoryRepository Categories { get; }
		public IDeviceRepository Devices { get; }
		public IZoneRepository Zones { get; }
		public async ValueTask<int> CompleteAsync()
		{
			return await _officeDbContext.SaveChangesAsync();
		}
		#endregion

		#region IDisposable

		private bool _isDisposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!_isDisposed)
			{
				if (disposing)
				{
					_officeDbContext.Dispose();
				}
			}

			_isDisposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		
	}
}