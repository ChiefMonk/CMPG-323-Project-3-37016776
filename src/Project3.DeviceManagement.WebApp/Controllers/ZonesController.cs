using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project3.DeviceManagement.WebAPP.Models;
using Project3.DeviceManagement.WebAPP.Models.Converters;
using Project3.DeviceManagement.Data.Repositories.Zone;
using Microsoft.AspNetCore.Http;
using Project3.DeviceManagement.Data.Exceptions;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Project3.DeviceManagement.WebAPP.Controllers
{
	public class ZonesController : Controller
	{
		private readonly IZoneRepository _zoneRepository;

		public ZonesController(IZoneRepository zoneRepository)
		{
			_zoneRepository = zoneRepository;
		}

		// GET: Zones
		public async Task<IActionResult> Index()
		{
			try
			{
				var zoneList = await _zoneRepository.GetAllCollectionAsync();
				return View(zoneList.ToModelZoneCollection());
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

		// GET: Zones/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if (id == null || id.Value == Guid.Empty)
				return NotFound();

			try
			{
				var zone = await _zoneRepository.GetByIdAsync(id.Value);
				return View(zone.ToModelZone());
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

		// GET: Zones/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Zones/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] ModelZone modelZone)
		{
			try
			{
				await _zoneRepository.AddAsync(modelZone.ToEntityZone());
				return RedirectToAction(nameof(Index));
			}
			catch (MyWebApiException ex)
			{
				return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message : ex.Message);
			}
		}

		// GET: Zones/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null || id.Value == Guid.Empty)
				return NotFound();

			try
			{
				var zone = await _zoneRepository.FindOneAsync(e => e.Id == id.Value);
				return View(zone.ToModelZone());
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

		// POST: Zones/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] ModelZone modelZone)
		{
			if (id != modelZone.ZoneId)
				return NotFound();

			string errorMessage = null;

			try
			{
				await _zoneRepository.UpdateAsync(modelZone.ToEntityZone());
				return RedirectToAction(nameof(Index));
			}
			catch (MyWebApiException ex)
			{
				errorMessage = ex.InnerException?.Message != null ? ex.InnerException.Message : ex.Message;
				errorMessage = $"{ex.StatusCode} : {errorMessage}";
			}
			catch (Exception ex)
			{
				errorMessage = ex.InnerException?.Message != null ? ex.InnerException.Message : ex.Message;
				errorMessage = $"{StatusCodes.Status500InternalServerError} : {errorMessage}";

				//return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
			}

			TempData["ErrorMessage"] = errorMessage;
			return RedirectToAction(nameof(Edit));
		}

		// GET: Zones/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null || id.Value == Guid.Empty)
				return NotFound();

			try
			{
				var zone = await _zoneRepository.FindOneAsync(e => e.Id == id.Value);
				return View(zone.ToModelZone());
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

		// POST: Zones/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			if (id == Guid.Empty)
				return NotFound();

			try
			{
				await _zoneRepository.RemoveAsync(id);
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
