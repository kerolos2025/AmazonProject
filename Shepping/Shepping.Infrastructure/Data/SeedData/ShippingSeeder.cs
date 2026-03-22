using Shepping.Core.Entities;
using Shepping.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Infrastructure.Data.SeedData
{
    public class ShippingSeeder
    {
        private readonly IShippingRepository _repository;

        public ShippingSeeder(IShippingRepository repository)
        {
            _repository = repository;
        }

        public async Task SeedAsync()
        {
            var seeds = new List<Shipping>
            {
                new Shipping { Name = "Cairo", Price = 50.00m },
                new Shipping { Name = "Alex", Price = 100.00m },
                new Shipping { Name = "Aswan", Price = 225.00m }
            };

            foreach (var item in seeds)
            {
                var existing = await _repository.GetShippingByName(item.Name);
                if (existing is null)
                {
                    await _repository.CreateShipping(item);
                }
            }
        }
    }
}
