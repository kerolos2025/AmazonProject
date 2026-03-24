using Discount.Core.Entities;
using Discount.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Data.SeedData
{
    public class DiscountSeeder
    {
        private readonly IDiscountRepository _repository;

        public DiscountSeeder(IDiscountRepository repository)
        {
            _repository = repository;
        }
        public async Task SeedAsync()
        {
            var seeds = new List<Discounts>
            {
                new Discounts { ProductId=2,Percentage=30,CreatedBy="System" },
                new Discounts { ProductId=3,Percentage=50,CreatedBy="System" },
               
            };
            if (!await _repository.HasData())
            {
                foreach (var item in seeds)
                {
     
                    await _repository.AddAsync(item);
                }
            }
        }
    }
}
