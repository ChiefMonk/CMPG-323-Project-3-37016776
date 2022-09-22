using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project3.DeviceManagement.Data.Db;
using Project3.DeviceManagement.Data.Entities;
using Project3.DeviceManagement.Data.Repositories.Category;
using Project3.DeviceManagement.Data.Repositories.Device;
using Project3.DeviceManagement.Data.Repositories.Zone;

namespace Project3.DeviceManagement.WebAPP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
	        //register database context
	        services.AddDbContext<ApplicationDbContext>(options =>
		        options.UseSqlServer(
			        Configuration.GetConnectionString("DefaultConnection")));

	        services.AddDbContext<ConnectedOfficeDbContext>(options =>
	        {
		        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
			        sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(maxRetryCount: 3); });
		        options.EnableDetailedErrors();

	        });

	        // register Identity
	        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
		        .AddEntityFrameworkStores<ApplicationDbContext>();

	        //Register Repositories
	        services.AddScoped<ICategoryRepository, CategoryRepository>();
	        services.AddScoped<IDeviceRepository, DeviceRepository>();
	        services.AddScoped<IZoneRepository, ZoneRepository>();

	        services.AddControllersWithViews();
	        services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
