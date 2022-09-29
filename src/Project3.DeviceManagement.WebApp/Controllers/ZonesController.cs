using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project3.DeviceManagement.WebAPP.Models;
using Project3.DeviceManagement.WebAPP.Models.Converters;
using Project3.DeviceManagement.Data.Repositories.Zone;
using Project3.DeviceManagement.Data.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace Project3.DeviceManagement.WebAPP.Controllers
{
	/// <summary>
	/// Zones Controller
	/// </summary>
	/// <seealso cref="Project3.DeviceManagement.WebAPP.Controllers.BaseController" />
	[Authorize]
	public class ZonesController : BaseController
	{
		private readonly IZoneRepository _zoneRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="ZonesController"/> class.
		/// </summary>
		/// <param name="zoneRepository">The zone repository.</param>
		public ZonesController(IZoneRepository zoneRepository)
		{
			_zoneRepository = zoneRepository;
		}

		// GET: Zones
		/// <summary>
		/// Indexes the specified load message.
		/// </summary>
		/// <param name="loadMessage">if set to <c>true</c> [load message].</param>
		/// <returns></returns>
		public async Task<IActionResult> Index(bool loadMessage = true)
		{
			try
			{
				var zoneList = await _zoneRepository.GetAllCollectionAsync();
				if (loadMessage)
					ProcessSuccess($"{zoneList.Count()} zones have been loaded successfully");

				return View(zoneList.ToModelZoneCollection());
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

		// GET: Zones/Details/5
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
				var zone = await _zoneRepository.GetByIdAsync(id.Value);
				ProcessSuccess($"Zone '{zone.ZoneName}' has been loaded successfully");
				return View(zone.ToModelZone());
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

		// GET: Zones/Create
		public IActionResult Create()
		{
			ProcessSuccess("Please enter the details below to CREATE a new Zone");
			return View();
		}

		// POST: Zones/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		/// <summary>
		/// Creates the specified model zone.
		/// </summary>
		/// <param name="modelZone">The model zone.</param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] ModelZone modelZone)
		{
			try
			{
				await _zoneRepository.AddAsync(modelZone.ToEntityZone(true));
				if (!string.IsNullOrWhiteSpace(modelZone?.ZoneName))
					ProcessSuccess($"Zone '{modelZone.ZoneName}' has been CREATED successfully", true);

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

		// GET: Zones/Edit/5
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
				var zone = await _zoneRepository.FindOneAsync(e => e.Id == id.Value);
				ProcessSuccess($"Zone '{zone.ZoneName}' has been loaded successfully");
				return View(zone.ToModelZone());
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

		// POST: Zones/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		/// <summary>
		/// Edits the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="modelZone">The model zone.</param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id,
			[Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] ModelZone modelZone)
		{
			if (id != modelZone.ZoneId)
				return NotFound();

			try
			{
				await _zoneRepository.UpdateAsync(modelZone.ToEntityZone());
				if (!string.IsNullOrWhiteSpace(modelZone?.ZoneName))
					ProcessSuccess($"Zone '{modelZone.ZoneName}' has been UPDATED successfully", true);

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

		// GET: Zones/Delete/5
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
				var zone = await _zoneRepository.FindOneAsync(e => e.Id == id.Value);
				ProcessSuccess($"Zone '{zone.ZoneName}' has been loaded successfully");
				return View(zone.ToModelZone());
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

		// POST: Zones/Delete/5
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
				var deletedId = await _zoneRepository.RemoveAsync(id);
				ProcessSuccess($"Zone with id '{deletedId}' has been DELETED successfully", true);

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
