using WMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace WMS.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<ProductItem> ProductItems { get; set; }

        DbSet<ProductList> ProductLists { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
