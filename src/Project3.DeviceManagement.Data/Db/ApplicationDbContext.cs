using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project3.DeviceManagement.Data.Db
{
	// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
	// If you have enabled NRTs for your project, then un-comment the following line:
	// #nullable disable
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	}
}
