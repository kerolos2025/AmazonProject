using Discount.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Core.Repositories
{
    public interface IDiscountRepository
    {
        Task<bool> HasData();
        Task<Discounts> GetByIdAsync(int id);
        Task<Discounts> GetByProductIdAsync(int id);

        Task<Discounts> AddAsync(Discounts discount);
       
        Task DeleteAsync(int id);
    }
}
