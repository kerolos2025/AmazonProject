using Microsoft.EntityFrameworkCore;
using Orders.Core.Entities;
using Orders.Core.Repositories;
using Orders.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) => _context = context;
        public async Task<Order> AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<List<Order>> GetByUserId(string userid)
        {
            return await _context.Orders.Where(x=>x.UserId==userid).ToListAsync();
        }
    }
}
