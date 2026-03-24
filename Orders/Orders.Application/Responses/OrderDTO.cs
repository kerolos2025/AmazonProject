using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Responses
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalProductsPrice { get; set; }
        public decimal Shipping { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
