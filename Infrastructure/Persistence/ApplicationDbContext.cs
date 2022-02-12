using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext , IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       //     => optionsBuilder.UseNpgsql("Host=localhost;Database=goe;Username=postgres;Password=admin");
    }
}
