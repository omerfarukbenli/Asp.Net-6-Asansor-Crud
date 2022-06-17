using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductRepository Productt { get; } 
        ICategoryRepository Categoryy { get; } 
        Task<int> SaveAsync();
    }
}
