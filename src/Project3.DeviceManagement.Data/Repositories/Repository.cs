using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Project3.DeviceManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Project3.DeviceManagement.Data.Db;
using Project3.DeviceManagement.Data.Exceptions;

namespace Project3.DeviceManagement.Data.Repositories
{
	/// <summary>
	/// Repository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="Project3.DeviceManagement.Data.Repositories.IRepository&lt;T&gt;" />
	public class Repository<T> : IRepository<T> where T : class, IDataEntity
	{
		protected readonly ConnectedOfficeDbContext _officeDbContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="Repository{T}"/> class.
		/// </summary>
		/// <param name="officeDbContext">The office database context.</param>
		protected Repository(ConnectedOfficeDbContext officeDbContext)
		{
			_officeDbContext = officeDbContext;
		}

		#region IRepository

		/// <summary>
		/// Gets the by identifier asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="includes">The includes.</param>
		/// <returns></returns>
		/// <exception cref="MyWebApiException">Please specify a valid {nameof(T)} ID</exception>
		public virtual async ValueTask<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
		{
			if (id == Guid.Empty)
				throw new MyWebApiException(StatusCodes.Status400BadRequest, $"Please specify a valid {nameof(T)} ID");

			var query = _officeDbContext.Set<T>().AsNoTracking().Where(e => e.Id == id);

			if (includes != null && includes.Any())
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			var entity =  await query.FirstOrDefaultAsync();

			if (entity == null)
				throw new MyWebApiException(StatusCodes.Status404NotFound, $"No {nameof(T)} with id = '{id}' has been found");

			return entity;
		}

		/// <summary>
		/// Gets all collection asynchronous.
		/// </summary>
		/// <param name="includes">The includes.</param>
		/// <returns></returns>
		public virtual async ValueTask<IEnumerable<T>> GetAllCollectionAsync(params Expression<Func<T, object>>[] includes)
		{
			var query = _officeDbContext.Set<T>().AsNoTracking();

			if (includes != null && includes.Any())
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return await query.ToListAsync();
		}

		/// <summary>
		/// Finds the one asynchronous.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <param name="includes">The includes.</param>
		/// <returns></returns>
		public virtual async ValueTask<T> FindOneAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
		{
			var query = _officeDbContext.Set<T>().AsNoTracking().Where(expression);

			if (includes != null && includes.Any())
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			var entity = await query.FirstOrDefaultAsync();

			if (entity == null)
				throw new MyWebApiException(StatusCodes.Status404NotFound, $"No {nameof(T)} has been found");

			return entity;
		}


		/// <summary>
		/// Finds the many asynchronous.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <param name="includes">The includes.</param>
		/// <returns></returns>
		public virtual async ValueTask<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
		{
			var query = _officeDbContext.Set<T>().AsNoTracking().Where(expression);

			if (includes != null && includes.Any())
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return await query.ToListAsync();
		}

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		/// <exception cref="MyWebApiException">A {nameof(T)} with id = '{entity.Id}' already exists</exception>
		public virtual async ValueTask<Guid> AddAsync(T entity)
		{
			if (await ExistsAsync(entity.Id))
				throw new MyWebApiException(StatusCodes.Status400BadRequest,
					$"A {nameof(T)} with id = '{entity.Id}' already exists");

			await _officeDbContext.Set<T>().AddAsync(entity);
			await _officeDbContext.SaveChangesAsync();

			return entity.Id;
		}

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		/// <exception cref="MyWebApiException">A {nameof(T)} with id = '{entity.Id}' does not exist</exception>
		public virtual async ValueTask<Guid> UpdateAsync(T entity)
		{
			if (!(await ExistsAsync(entity.Id)))
				throw new MyWebApiException(StatusCodes.Status400BadRequest,
					$"A {nameof(T)} with id = '{entity.Id}' does not exist");

			_officeDbContext.Entry(entity).State = EntityState.Modified;
			await _officeDbContext.SaveChangesAsync();

			return entity.Id;
		}

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		/// <exception cref="MyWebApiException">A {nameof(T)} with id = '{id}' does not exist</exception>
		public virtual async ValueTask<Guid> RemoveAsync(Guid id)
		{
			var entity = await _officeDbContext.Set<T>().AsTracking().FirstOrDefaultAsync(e => e.Id == id);

			if (entity == null)
				throw new MyWebApiException(StatusCodes.Status400BadRequest,
					$"A {nameof(T)} with id = '{id}' does not exist");

			_officeDbContext.Set<T>().Remove(entity);
			await _officeDbContext.SaveChangesAsync();

			return id;
		}

		#endregion

		#region Privates

		/// <summary>
		/// Does entity exist.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>boolean</returns>
		/// <exception cref="MyWebApiException">Please specify a valid {nameof(T)} ID</exception>
		private async ValueTask<bool> ExistsAsync(Guid id)
		{
			if (id == Guid.Empty)
				throw new MyWebApiException(StatusCodes.Status400BadRequest, $"Please specify a valid {nameof(T)} ID");

			return await _officeDbContext.Set<T>().AsTracking().AnyAsync(e => e.Id == id);
		}

		#endregion
	}
}