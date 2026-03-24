using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Core.Entities
{
    public class Discounts:Base
    {
        public int ProductId { get; set; }
        public int Percentage { get; set; }
    }
}
