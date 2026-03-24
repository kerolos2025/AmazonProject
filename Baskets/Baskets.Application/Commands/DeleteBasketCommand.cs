using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Commands
{
    public class DeleteBasketCommand:IRequest<bool>
    {
        public DeleteBasketCommand(string userId)
        {
            this.UserId= userId;
        }
        public string UserId { get; set; }
    }
}
