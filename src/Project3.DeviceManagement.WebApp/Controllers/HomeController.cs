using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project3.DeviceManagement.WebAPP.Models;

namespace Project3.DeviceManagement.WebAPP.Controllers
{
	/// <summary>
	/// HomeController
	/// </summary>
	/// <seealso cref="Project3.DeviceManagement.WebAPP.Controllers.BaseController" />
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeController"/> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Indexes this instance.
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Privacies this instance.
		/// </summary>
		/// <returns></returns>
		public IActionResult Privacy()
		{
			return View();
		}

		/// <summary>
		/// Errors this instance.
		/// </summary>
		/// <returns></returns>
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
