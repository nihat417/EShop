using EShop.Application.Repositories.ProductRepository;
using EShop.Application.Repositories;
using EShop.Persistence.Contexts;
using EShop.Application.Repositories.OrderRepository;
using EShop.Application.Repositories.CustomerRepository;

namespace EShop.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EShopDbContext _context;

		public IProductReadRepository ProductReadRepository { get; }
		public IProductWriteRepository ProductWriteRepository { get; }
		public IOrderReadRepository OrderReadRepository { get; }
		public IOrderWriteRepository OrderWriteRepository { get; }
		public ICustomerReadRepository CustomerReadRepository { get; }
		public ICustomerWriteRepository CustomerWriteRepository { get; }

		public UnitOfWork(
			EShopDbContext context,
			IProductReadRepository productReadRepository,
			IProductWriteRepository productWriteRepository,
			ICustomerWriteRepository customerWriteRepository,
			ICustomerReadRepository customerReadRepository,
			IOrderReadRepository orderReadRepository,
			IOrderWriteRepository orderWriteRepository)
		{
			_context = context;
			ProductReadRepository = productReadRepository;
			ProductWriteRepository = productWriteRepository;
			CustomerWriteRepository = customerWriteRepository;
			CustomerReadRepository = customerReadRepository;
			OrderReadRepository = orderReadRepository;
			OrderWriteRepository = orderWriteRepository;
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
