using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Core.Entities
{
    public class Basket
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
