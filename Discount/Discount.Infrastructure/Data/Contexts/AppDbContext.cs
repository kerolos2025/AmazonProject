using Discount.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Discounts> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discounts>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.ProductId).IsRequired();
                entity.Property(p => p.Percentage).IsRequired();
               
            });
        }
    }
}
