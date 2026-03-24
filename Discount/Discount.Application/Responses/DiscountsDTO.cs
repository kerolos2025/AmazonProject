using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Responses
{
    public class DiscountsDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Percentage { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
