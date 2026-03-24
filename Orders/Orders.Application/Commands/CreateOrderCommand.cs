using MediatR;
using Orders.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Commands
{
    public class CreateOrderCommand:IRequest<OrderDTO>
    {
        
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalProductsPrice { get; set; }
        public decimal Shipping { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
