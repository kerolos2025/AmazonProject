using Shepping.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Core.Repositories
{
    public interface IShippingRepository
    {
        Task<List<Shipping>> GetAllShipping();
        Task<Shipping> GetShippingByName(string name);
        Task<Shipping> CreateShipping(Shipping shipping);
        Task<bool> UpdateShipping(Shipping shipping);
        Task<bool> DeleteShipping(string id);
    }
}
