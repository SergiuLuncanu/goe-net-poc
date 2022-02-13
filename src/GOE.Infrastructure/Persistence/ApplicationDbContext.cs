using GOE.Application.Common.Interfaces;
using GOE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GOE.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
