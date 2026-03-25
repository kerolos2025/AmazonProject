using Baskets.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Commands
{
    public class CreateBasketCommand:IRequest<bool>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal? Shipping { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
