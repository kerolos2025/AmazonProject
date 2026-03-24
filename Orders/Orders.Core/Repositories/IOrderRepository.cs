using Orders.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<List<Order>> GetByUserId(string userid);

        Task<Order> AddAsync(Order order);
    }
}
