using Discount.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Queries
{
    public class GetDiscountByProductIdQuery:IRequest<DiscountsDTO>
    {
        public int ProductId { get; set; }
        public GetDiscountByProductIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
