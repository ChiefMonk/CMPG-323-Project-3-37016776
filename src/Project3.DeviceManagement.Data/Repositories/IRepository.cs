using Project3.DeviceManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project3.DeviceManagement.Data.Repositories
{
	public interface IRepository<T> where T : class, IDataEntity
	{
		ValueTask<T> GetByIdAsync(Guid id);
		ValueTask<IEnumerable<T>> GetAllCollectionAsync();
		ValueTask<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
		ValueTask<Guid> AddAsync(T entity);
		ValueTask<Guid> UpdateAsync(T entity);
		ValueTask<Guid> RemoveAsync(Guid id);
		ValueTask<bool> ExistsAsync(Guid id);
	}
}