using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;
using Project3.DeviceManagement.Data.Exceptions;
using Project3.DeviceManagement.Data.Repositories.Category;
using Project3.DeviceManagement.WebAPP.Models;
using Project3.DeviceManagement.WebAPP.Models.Converters;

namespace Project3.DeviceManagement.WebAPP.Controllers
{
	/// <summary>
	/// CategoriesController
	/// </summary>
	/// <seealso cref="Project3.DeviceManagement.WebAPP.Controllers.BaseController" />
	public class CategoriesController : BaseController
	{
		private readonly ICategoryRepository _categoryRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoriesController"/> class.
		/// </summary>
		/// <param name="categoryRepository">The category repository.</param>
		public CategoriesController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		// GET: Categories
		/// <summary>
		/// Indexes the specified load message.
		/// </summary>
		/// <param name="loadMessage">if set to <c>true</c> [load message].</param>
		/// <returns></returns>
		public async Task<IActionResult> Index(bool loadMessage = true)
		{
			try
			{
				var categoryList = await _categoryRepository.GetAllCollectionAsync();
				if (loadMessage) 
					ProcessSuccess($"{categoryList.Count()} categories have been loaded successfully");
				return View(categoryList.ToModelCategoryCollection());
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

		// GET: Categories/Details/5
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
				var category = await _categoryRepository.GetByIdAsync(id.Value);
				ProcessSuccess($"Category '{category.CategoryName}' has been loaded successfully");
				return View(category.ToModelCategory());
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

		// GET: Categories/Create
		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns></returns>
		public IActionResult Create()
		{
			ProcessSuccess("Please enter the details below to CREATE a new Category");
			return View();
		}

		// POST: Categories/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		/// <summary>
		/// Creates the specified model category.
		/// </summary>
		/// <param name="modelCategory">The model category.</param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(
			[Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")]
			ModelCategory modelCategory)
		{
			try
			{
				await _categoryRepository.AddAsync(modelCategory.ToEntityCategory(true));
				if (!string.IsNullOrWhiteSpace(modelCategory?.CategoryName))
					ProcessSuccess($"Category '{modelCategory.CategoryName}' has been CREATED successfully", true);
				
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

		// GET: Categories/Edit/5
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
				var category = await _categoryRepository.FindOneAsync(e => e.Id == id.Value);
				ProcessSuccess($"Category '{category.CategoryName}' has been loaded successfully");
				return View(category.ToModelCategory());
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

		// POST: Categories/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		/// <summary>
		/// Edits the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="modelCategory">The model category.</param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id,
			[Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")]
			ModelCategory modelCategory)
		{
			if (id != modelCategory.CategoryId)
				return NotFound();

			try
			{
				await _categoryRepository.UpdateAsync(modelCategory.ToEntityCategory());
				if (!string.IsNullOrWhiteSpace(modelCategory?.CategoryName))
					ProcessSuccess($"Category '{modelCategory.CategoryName}' has been UPDATED successfully", true);

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

		// GET: Categories/Delete/5
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
				var category = await _categoryRepository.FindOneAsync(e => e.Id == id.Value);
				ProcessSuccess($"Category '{category.CategoryName}' has been loaded successfully");
				return View(category.ToModelCategory());
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

		// POST: Categories/Delete/5
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
				var deletedId = await _categoryRepository.RemoveAsync(id);
				ProcessSuccess($"Category with id '{deletedId}' has been DELETED successfully", true);

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
