using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project3.DeviceManagement.Data.Exceptions;
using Project3.DeviceManagement.Data.Repositories.Category;
using Project3.DeviceManagement.Data.Repositories.Device;
using Project3.DeviceManagement.Data.Repositories.Zone;
using Project3.DeviceManagement.WebAPP.Models;
using Project3.DeviceManagement.WebAPP.Models.Converters;

namespace Project3.DeviceManagement.WebAPP.Controllers
{
	public class DevicesController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IZoneRepository _zoneRepository;
		private readonly IDeviceRepository _deviceRepository;

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
		public async Task<IActionResult> Index()
		{
			try
			{
				var deviceList = await _deviceRepository.GetAllCollectionAsync(d => d.Category, d => d.Zone);
				return View(deviceList.ToModelDeviceCollection());
			}
			catch (MyWebApiException ex)
			{
				return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
		}

		// GET: Devices/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if (id == null || id.Value == Guid.Empty)
				return NotFound();

			try
			{
				var device = await _deviceRepository.GetByIdAsync(id.Value, d => d.Category, d => d.Zone);
				return View(device.ToModelDevice());
			}
			catch (MyWebApiException ex)
			{
				return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
		}

		// GET: Devices/Create
		public async Task<IActionResult> Create()
		{
			try
			{
				var categoryList = await _categoryRepository.GetAllCollectionAsync();
				var zoneList = await _zoneRepository.GetAllCollectionAsync();

				ViewData["CategoryId"] = new SelectList(categoryList.ToModelCategoryCollection(), "CategoryId", "CategoryName");
				ViewData["ZoneId"] = new SelectList(zoneList.ToModelZoneCollection(), "ZoneId", "ZoneName");
				return View();
			}
			catch (MyWebApiException ex)
			{
				return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}

		}

		// POST: Devices/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(
			[Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")]
			ModelDevice modelDevice)
		{
			try
			{
				await _deviceRepository.AddAsync(modelDevice.ToEntityDevice());
				return RedirectToAction(nameof(Index));
			}
			catch (MyWebApiException ex)
			{
				return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
		}

		// GET: Devices/Edit/5
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

				return View(device.ToModelDevice());
			}
			catch (MyWebApiException ex)
			{
				return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
		}

		// POST: Devices/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
				return RedirectToAction(nameof(Index));
			}
			catch (MyWebApiException ex)
			{
				return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
		}

		// GET: Devices/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null || id.Value == Guid.Empty)
				return NotFound();

			try
			{
				var device = await _deviceRepository.FindOneAsync(e=>e.Id == id.Value, d => d.Category, d => d.Zone);
				return View(device.ToModelDevice());
			}
			catch (MyWebApiException ex)
			{
				return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
		}

		// POST: Devices/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			if (id == Guid.Empty)
				return NotFound();

			try
			{
				await _deviceRepository.RemoveAsync(id);
				return RedirectToAction(nameof(Index));
			}
			catch (MyWebApiException ex)
			{
				return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
		}

	}
}
