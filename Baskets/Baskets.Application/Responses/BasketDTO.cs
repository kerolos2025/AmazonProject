using Baskets.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Responses
{
    public class BasketDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal? Shipping { get; set; }
        public List<BasketItemDTO> Items { get; set; } = new List<BasketItemDTO>();
    }
}
