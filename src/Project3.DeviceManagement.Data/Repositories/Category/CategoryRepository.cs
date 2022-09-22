using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Project3.DeviceManagement.Data.Entities;
using System.Net;
using Project3.DeviceManagement.Data.Db;

namespace Project3.DeviceManagement.Data.Repositories.Category
{
	public class CategoryRepository : Repository<EntityCategory>, ICategoryRepository
	{
		public CategoryRepository(ConnectedOfficeDbContext dbContext) : base(dbContext)
		{
		}

	}
}