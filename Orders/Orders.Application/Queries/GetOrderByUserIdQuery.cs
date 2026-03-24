using MediatR;
using Orders.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Queries
{
    public class GetOrderByUserIdQuery:IRequest<List<OrderDTO>>
    {
        public string UserId { get; set; }

        public GetOrderByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
