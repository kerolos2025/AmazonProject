using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Responses
{
    public class BasketItemDTO
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string ImagePath { get; set; }
    }
}
