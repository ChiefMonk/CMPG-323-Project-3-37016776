using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.WebAPI.DAL.Converters;
using Project3.DeviceManagement.Data.Repositories.Category;
using Project3.DeviceManagement.Shared.Utils.Exceptions;
using Project3.DeviceManagement.WebAPP.Models;

namespace Project3.DeviceManagement.WebAPP.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
	        _categoryRepository = categoryRepository;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
	        try
	        {
		        var entityList = await _categoryRepository.GetAllCollectionAsync();
		        return View(entityList.ToDtoCategoryCollection());
	        }
	        catch (MyWebApiException ex)
	        {
		        return StatusCode(ex.StatusCode, ex.Message);
	        }
	        catch (Exception ex)
	        {
		        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
	        }
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
	        if (id == null || id.Value == Guid.Empty)
		        return NotFound();

	        try
	        {
		        var category = await _categoryRepository.GetByIdAsync(id.Value);
		        return View(category.ToDtoCategory());
	        }
	        catch (MyWebApiException ex)
	        {
		        return StatusCode(ex.StatusCode, ex.Message);
	        }
	        catch (Exception ex)
	        {
		        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
	        }

        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
	        [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")]
	        Category category)
        {
	        try
	        {
		        await _categoryRepository.AddAsync(category.ToEntityCategory());
		        return RedirectToAction(nameof(Index));
	        }
	        catch (MyWebApiException ex)
	        {
		        return StatusCode(ex.StatusCode, ex.Message);
	        }
	        catch (Exception ex)
	        {
		        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
	        }
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
	        if (id == null || id.Value == Guid.Empty)
		        return NotFound();

	        try
	        {
		        var category = await _categoryRepository.GetByIdAsync(id.Value);
		        return View(category.ToDtoCategory());
	        }
	        catch (MyWebApiException ex)
	        {
		        return StatusCode(ex.StatusCode, ex.Message);
	        }
	        catch (Exception ex)
	        {
		        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
	        }
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
	        [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
	        if (id != category.CategoryId)
		        return NotFound();

	        try
	        {
		        await _categoryRepository.UpdateAsync(category.ToEntityCategory());
		        return RedirectToAction(nameof(Index));
	        }
	        catch (MyWebApiException ex)
	        {
		        return StatusCode(ex.StatusCode, ex.Message);
	        }
	        catch (Exception ex)
	        {
		        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
	        }
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
	        if (id == null || id.Value == Guid.Empty)
		        return NotFound();

	        try
	        {
		        var category = await _categoryRepository.GetByIdAsync(id.Value);
		        return View(category.ToDtoCategory());
	        }
	        catch (MyWebApiException ex)
	        {
		        return StatusCode(ex.StatusCode, ex.Message);
	        }
	        catch (Exception ex)
	        {
		        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
	        }

        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
	        if (id == Guid.Empty)
		        return NotFound();

	        try
	        {
		        await _categoryRepository.RemoveAsync(id);
		        return RedirectToAction(nameof(Index));
	        }
	        catch (MyWebApiException ex)
	        {
		        return StatusCode(ex.StatusCode, ex.Message);
	        }
	        catch (Exception ex)
	        {
		        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
	        }
        }
    }
}
