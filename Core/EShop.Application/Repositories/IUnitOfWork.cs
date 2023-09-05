using EShop.Application.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IProductReadRepository ProductReadRepository { get; }
		IProductWriteRepository ProductWriteRepository { get; }

		Task<int> SaveChangesAsync();
	}
}
