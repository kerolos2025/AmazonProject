using Discount.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Commands
{
    public class CreateDiscountCommand:IRequest<DiscountsDTO>
    {
        public int ProductId { get; set; }
        public int Percentage { get; set; }
        public string CreatedBy { get; set; }
    }
}
