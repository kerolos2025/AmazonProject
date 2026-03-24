using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Core.Entities
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string ImagePath { get; set; }
    }
}
