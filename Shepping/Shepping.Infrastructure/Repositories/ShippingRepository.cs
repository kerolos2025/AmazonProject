using MongoDB.Driver;
using Shepping.Core.Entities;
using Shepping.Core.Repositories;
using Shepping.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shepping.Infrastructure.Repositories
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly IShippingContext _context;

        public ShippingRepository(IShippingContext context)
        {
            _context = context;
        }
        public async Task<Shipping> GetShippingById(string id)
        {
            return await _context.Shipping
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();
        }
        public async Task<List<Shipping>> GetAllShipping()
        {
            return await _context.Shipping.Find(p => true).ToListAsync();
        }
        public async Task<Shipping> GetShippingByName(string name)
        {
            return await _context.Shipping
            .Find(p => p.Name == name)
            .FirstOrDefaultAsync();
        }
        public async Task<Shipping> CreateShipping(Shipping shipping)
        {
            await _context.Shipping.InsertOneAsync(shipping);
            return shipping;
        }

        public async Task<bool> DeleteShipping(string id)
        {
            var deleted= await _context.Shipping.DeleteOneAsync(p => p.Id == id);
            return deleted.IsAcknowledged && deleted.DeletedCount > 0;
        }
        public async Task<bool> UpdateShipping(Shipping shipping)
        {
            var updated = await _context.Shipping.ReplaceOneAsync(p => p.Id == shipping.Id, shipping);
            return updated.IsAcknowledged && updated.ModifiedCount > 0;
        }

       
    }
}
