using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Project3.DeviceManagement.Data.Exceptions;
using Project3.DeviceManagement.Data.Repositories.Category;
using Project3.DeviceManagement.Data.Repositories.Device;
using Project3.DeviceManagement.Data.Repositories.Zone;
using Project3.DeviceManagement.WebAPP.Models;
using Project3.DeviceManagement.WebAPP.Models.Converters;

namespace Project3.DeviceManagement.WebAPP.Controllers
{
	/// <summary>
	/// DevicesController
	/// </summary>
	/// <seealso cref="Project3.DeviceManagement.WebAPP.Controllers.BaseController" />
	public class DevicesController : BaseController
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IZoneRepository _zoneRepository;
		private readonly IDeviceRepository _deviceRepository;
		private static Random rand = new Random();
		/// <summary>
		/// Initializes a new instance of the <see cref="DevicesController"/> class.
		/// </summary>
		/// <param name="categoryRepository">The category repository.</param>
		/// <param name="zoneRepository">The zone repository.</param>
		/// <param name="deviceRepository">The device repository.</param>
		public DevicesController(
			ICategoryRepository categoryRepository,
			IZoneRepository zoneRepository,
			IDeviceRepository deviceRepository)
		{
			_categoryRepository = categoryRepository;
			_zoneRepository = zoneRepository;
			_deviceRepository = deviceRepository;
		}

		// GET: Devices
		/// <summary>
		/// Indexes the specified load message.
		/// </summary>
		/// <param name="loadMessage">if set to <c>true</c> [load message].</param>
		/// <returns></returns>
		public async Task<IActionResult> Index(bool loadMessage = true)
		{
			try
			{
				var deviceList = await _deviceRepository.GetAllCollectionAsync(d => d.Category, d => d.Zone);
				if (loadMessage) 
					ProcessSuccess($"{deviceList.Count()} devices have been loaded successfully");

				return View(deviceList.ToModelDeviceCollection());
			}
			catch (MyWebApiException ex)
			{
				ProcessException(ex);
			}
			catch (Exception ex)
			{
				ProcessException(ex);
			}

			return View();
		}

		// GET: Devices/Details/5
		/// <summary>
		/// Detailses the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IActionResult> Details(Guid? id)
		{
			if (id == null || id.Value == Guid.Empty)
				return NotFound();

			try
			{
				var device = await _deviceRepository.GetByIdAsync(id.Value, d => d.Category, d => d.Zone);
				ProcessSuccess($"Device '{device.DeviceName}' has been loaded successfully");
				return View(device.ToModelDevice());
			}
			catch (MyWebApiException ex)
			{
				ProcessException(ex);
			}
			catch (Exception ex)
			{
				ProcessException(ex);
			}

			return RedirectToAction(nameof(Index), new { loadMessage = false });
		}

		// GET: Devices/Create
		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> Create()
		{
			try
			{
				var categoryList = await _categoryRepository.GetAllCollectionAsync();
				var zoneList = await _zoneRepository.GetAllCollectionAsync();

				ViewData["CategoryId"] = new SelectList(categoryList.ToModelCategoryCollection(), "CategoryId", "CategoryName");
				ViewData["ZoneId"] = new SelectList(zoneList.ToModelZoneCollection(), "ZoneId", "ZoneName");

				ProcessSuccess("Please enter the details below to CREATE a new Device");
				return View();
			}
			catch (MyWebApiException ex)
			{
				ProcessException(ex);
			}
			catch (Exception ex)
			{
				ProcessException(ex);
			}

			return View();
		}

		// POST: Devices/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		/// <summary>
		/// Creates the specified model device.
		/// </summary>
		/// <param name="modelDevice">The model device.</param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(
			[Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")]
			ModelDevice modelDevice)
		{
			try
			{
				await _deviceRepository.AddAsync(modelDevice.ToEntityDevice(true));
				if (!string.IsNullOrWhiteSpace(modelDevice?.DeviceName))
					ProcessSuccess($"Device '{modelDevice.DeviceName}' has been CREATED successfully", true);

				return RedirectToAction(nameof(Index), new { loadMessage = false });
			}
			catch (MyWebApiException ex)
			{
				ProcessException(ex);
			}
			catch (Exception ex)
			{
				ProcessException(ex);
			}
			return View();
		}

		// GET: Devices/Edit/5
		/// <summary>
		/// Edits the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null || id.Value == Guid.Empty)
				return NotFound();

			try
			{
				var device = await _deviceRepository.FindOneAsync(e => e.Id == id.Value, d => d.Category, d => d.Zone);
				var categoryList = await _categoryRepository.GetAllCollectionAsync();
				var zoneList = await _zoneRepository.GetAllCollectionAsync();

				ViewData["CategoryId"] = new SelectList(categoryList.ToModelCategoryCollection(), "CategoryId", "CategoryName", device.CategoryId);
				ViewData["ZoneId"] = new SelectList(zoneList.ToModelZoneCollection(), "ZoneId", "ZoneName", device.ZoneId);

				ProcessSuccess($"Device '{device.DeviceName}' has been loaded successfully");
				return View(device.ToModelDevice());
			}
			catch (MyWebApiException ex)
			{
				ProcessException(ex);
			}
			catch (Exception ex)
			{
				ProcessException(ex);
			}

			return RedirectToAction(nameof(Index), new { loadMessage = false });
		}

		// POST: Devices/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.[HttpPost]
		/// <summary>
		/// Edits the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="modelDevice">The model device.</param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id,
			[Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] ModelDevice modelDevice)
		{
			if (id != modelDevice.DeviceId)
				return NotFound();

			try
			{
				await _deviceRepository.UpdateAsync(modelDevice.ToEntityDevice());
				if (!string.IsNullOrWhiteSpace(modelDevice?.DeviceName))
					ProcessSuccess($"Device '{modelDevice.DeviceName}' has been UPDATED successfully", true);
				return RedirectToAction(nameof(Index), new { loadMessage = false });
			}
			catch (MyWebApiException ex)
			{
				ProcessException(ex);
			}
			catch (Exception ex)
			{
				ProcessException(ex);
			}
		
			return View();
		}

		// GET: Devices/Delete/5
		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null || id.Value == Guid.Empty)
				return NotFound();

			try
			{
				var device = await _deviceRepository.FindOneAsync(e=>e.Id == id.Value, d => d.Category, d => d.Zone);
				ProcessSuccess($"Device '{device.DeviceName}' has been loaded successfully");
				return View(device.ToModelDevice());
			}
			catch (MyWebApiException ex)
			{
				ProcessException(ex);
			}
			catch (Exception ex)
			{
				ProcessException(ex);
			}

			return RedirectToAction(nameof(Index), new { loadMessage = false });
		}

		// POST: Devices/Delete/5
		/// <summary>
		/// Deletes the confirmed.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			if (id == Guid.Empty)
				return NotFound();

			try
			{
				var deletedId = await _deviceRepository.RemoveAsync(id);
				ProcessSuccess($"Device with id '{deletedId}' has been DELETED successfully", true);

				return RedirectToAction(nameof(Index), new { loadMessage = false });
			}
			catch (MyWebApiException ex)
			{
				ProcessException(ex);
			}
			catch (Exception ex)
			{
				ProcessException(ex);
			}
			
			return View();
		}
	}
}
