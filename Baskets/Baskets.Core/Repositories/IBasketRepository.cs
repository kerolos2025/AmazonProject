using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Core.Repositories
{
    public interface IBasketRepository
    {
        Task SetAsync(string key, object value);
        Task<T> GetAsync<T>(string key);
        Task<bool> DeleteAsync(string key);
        //remaing for grpc and rabbitMQ
    }
}
