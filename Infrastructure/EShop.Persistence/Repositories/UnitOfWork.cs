using EShop.Application.Repositories.ProductRepository;
using EShop.Application.Repositories;
using EShop.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EShopDbContext _context;

		public IProductReadRepository ProductReadRepository { get; }
		public IProductWriteRepository ProductWriteRepository { get; }

		public UnitOfWork(
			EShopDbContext context,
			IProductReadRepository productReadRepository,
			IProductWriteRepository productWriteRepository)
		{
			_context = context;
			ProductReadRepository = productReadRepository;
			ProductWriteRepository = productWriteRepository;
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
