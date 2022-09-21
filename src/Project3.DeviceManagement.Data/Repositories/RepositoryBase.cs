using Project3.DeviceManagement.WebAPP.Data;

namespace Project3.DeviceManagement.Data.Repositories
{
    public abstract class RepositoryBase
    {
	    protected ConnectedOfficeDbContext _officeDbContext;

			protected RepositoryBase(ConnectedOfficeDbContext officeDbContext)
			{
				_officeDbContext = officeDbContext;
			}
	}
}