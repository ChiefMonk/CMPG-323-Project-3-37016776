using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3.DeviceManagement.Data.Exceptions;
using Project3.DeviceManagement.Data.Repositories.Category;
using Project3.DeviceManagement.WebAPP.Models;
using Project3.DeviceManagement.WebAPP.Models.Converters;

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
		        return View(entityList.ToModelCategoryCollection());
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

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
	        if (id == null || id.Value == Guid.Empty)
		        return NotFound();

	        try
	        {
		        var category = await _categoryRepository.GetByIdAsync(id.Value);
		        return View(category.ToModelCategory());
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
	        ModelCategory modelCategory)
        {
	        try
	        {
		        await _categoryRepository.AddAsync(modelCategory.ToEntityCategory());
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

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
	        if (id == null || id.Value == Guid.Empty)
		        return NotFound();

	        try
	        {
		        var category = await _categoryRepository.FindOneAsync(e => e.Id == id.Value);

		        return View(category.ToModelCategory());
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

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
	        [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] ModelCategory modelCategory)
        {
	        if (id != modelCategory.CategoryId)
		        return NotFound();

	        try
	        {
		        await _categoryRepository.UpdateAsync(modelCategory.ToEntityCategory());
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

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
	        if (id == null || id.Value == Guid.Empty)
		        return NotFound();

	        try
	        {
		        var category = await _categoryRepository.FindOneAsync(e => e.Id == id.Value);
		        return View(category.ToModelCategory());
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
		        return StatusCode(ex.StatusCode, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
	        }
	        catch (Exception ex)
	        {
		        return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message != null ? ex.InnerException.Message: ex.Message);
	        }
        }
    }
}
