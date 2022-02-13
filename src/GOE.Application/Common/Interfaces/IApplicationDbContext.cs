using GOE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GOE.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { set; get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
