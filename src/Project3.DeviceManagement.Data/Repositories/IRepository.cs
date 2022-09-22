using Project3.DeviceManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project3.DeviceManagement.Data.Repositories
{
	public interface IRepository<T> where T : class, IDataEntity
	{
		/// <summary>
		/// Gets the by identifier asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="includes">The includes.</param>
		/// <returns></returns>
		ValueTask<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);

		/// <summary>
		/// Gets all collection asynchronous.
		/// </summary>
		/// <param name="includes">The includes.</param>
		/// <returns></returns>
		ValueTask<IEnumerable<T>> GetAllCollectionAsync(params Expression<Func<T, object>>[] includes);


		/// <summary>
		/// Finds the one asynchronous.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <param name="includes">The includes.</param>
		/// <returns></returns>
		ValueTask<T> FindOneAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);


		/// <summary>
		/// Finds the many asynchronous.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <param name="includes">The includes.</param>
		/// <returns></returns>
		ValueTask<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		ValueTask<Guid> AddAsync(T entity);

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		ValueTask<Guid> UpdateAsync(T entity);

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		ValueTask<Guid> RemoveAsync(Guid id);
	}
}