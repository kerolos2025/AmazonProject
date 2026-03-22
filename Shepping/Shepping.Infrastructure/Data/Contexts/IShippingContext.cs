using MongoDB.Driver;
using Shepping.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Infrastructure.Data.Contexts
{
    public interface IShippingContext
    {
        IMongoCollection<Shipping> Shipping { get; }

    }
}
