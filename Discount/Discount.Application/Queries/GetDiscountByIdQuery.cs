using Discount.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Queries
{
    public class GetDiscountByIdQuery:IRequest<DiscountsDTO>
    {
        public int Id { get; set; }

        public GetDiscountByIdQuery(int id)
        {
            Id = id;
        }

        
    }
}
