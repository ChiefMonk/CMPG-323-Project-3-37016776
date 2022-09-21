using Project3.DeviceManagement.Data.Repositories.Category;

namespace Project3.DeviceManagement.WebAPI.Services.Category
{
	public class CategoryService : ServiceBase, ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
	}
}