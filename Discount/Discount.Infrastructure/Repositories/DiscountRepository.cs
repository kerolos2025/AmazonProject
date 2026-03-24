using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly AppDbContext _context;

        public DiscountRepository(AppDbContext context) => _context = context;
        public async Task<Discounts> AddAsync(Discounts discount)
        {
            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            _context.Discounts.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Discounts> GetByIdAsync(int id)
        {
           return await _context.Discounts.FindAsync(id);
        }

        public async Task<Discounts> GetByProductIdAsync(int id)
        {
            return await _context.Discounts.Where(x=>x.ProductId==id).FirstOrDefaultAsync();
        }

        public async Task<bool> HasData()
        {
           // _context.Discounts.Any();
             return await _context.Discounts.AnyAsync();
        }
    }
}
