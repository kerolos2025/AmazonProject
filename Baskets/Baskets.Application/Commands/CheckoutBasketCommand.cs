using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Commands
{
    public class CheckoutBasketCommand:IRequest<bool>
    {
        public string UserId { get; set; }

        public CheckoutBasketCommand(string userId)
        {
            UserId = userId;
        }
    }
}
