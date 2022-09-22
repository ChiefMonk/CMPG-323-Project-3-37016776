using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Project3.DeviceManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Project3.DeviceManagement.Shared.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Project3.DeviceManagement.Data.Db;

namespace Project3.DeviceManagement.Data.Repositories
{
	public class Repository<T> : IRepository<T> where T : class, IDataEntity
	{
		private readonly ConnectedOfficeDbContext _officeDbContext;

		protected Repository(ConnectedOfficeDbContext officeDbContext)
		{
			_officeDbContext = officeDbContext;
		}

		public async ValueTask<T> GetByIdAsync(Guid id)
		{
			if (id == Guid.Empty)
				throw new MyWebApiException(StatusCodes.Status400BadRequest, $"Please specify a valid {nameof(T)} ID");

			return await _officeDbContext.Set<T>()
				.AsNoTracking()
				.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async ValueTask<IEnumerable<T>> GetAllCollectionAsync()
		{
			return await _officeDbContext.Set<T>().AsNoTracking().ToListAsync();
		}

		public async ValueTask<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
		{
			return await _officeDbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();
		}

		public async ValueTask<Guid> AddAsync(T entity)
		{
			if (await ExistsAsync(entity.Id))
				throw new MyWebApiException(StatusCodes.Status400BadRequest, $"A {nameof(T)} with id = '{entity.Id}' already exists");

			await _officeDbContext.Set<T>().AddAsync(entity);
			await _officeDbContext.SaveChangesAsync();

			return entity.Id;
		}

		public async ValueTask<Guid> UpdateAsync(T entity)
		{
			if (!(await ExistsAsync(entity.Id)))
				throw new MyWebApiException(StatusCodes.Status400BadRequest, $"A {nameof(T)} with id = '{entity.Id}' does not exist");

			_officeDbContext.Entry(entity).State = EntityState.Modified;
			await _officeDbContext.SaveChangesAsync();

			return entity.Id;
		}

		public async ValueTask<Guid> RemoveAsync(Guid id)
		{
			var entity = await _officeDbContext.Set<T>().AsTracking().FirstOrDefaultAsync(e => e.Id == id);

			if (entity == null)
				throw new MyWebApiException(StatusCodes.Status400BadRequest,
					$"A {nameof(T)} with id = '{id}' does not exist");

			_officeDbContext.Set<T>().Remove(entity);
			await _officeDbContext.SaveChangesAsync();

			return id;
		}

		public async ValueTask<bool> ExistsAsync(Guid id)
		{
			if (id == Guid.Empty)
				throw new MyWebApiException(StatusCodes.Status400BadRequest, $"Please specify a valid {nameof(T)} ID");

			return await _officeDbContext.Set<T>().AsTracking().AnyAsync(e => e.Id == id);
		}
	}
}