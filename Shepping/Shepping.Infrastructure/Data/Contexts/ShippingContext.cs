using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shepping.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Shepping.Infrastructure.Data.Contexts
{
    public class ShippingContext : IShippingContext
    {
       

        private readonly IMongoDatabase _database;

        public ShippingContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            _database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
        }

        public IMongoCollection<Shipping> Shipping =>
            _database.GetCollection<Shipping>("ShippingTable");

    }
}
