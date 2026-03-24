using Baskets.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Queries
{
    public class GetBasketQuery:IRequest<BasketDTO>
    {
        public string UserId { get; set; }

        public GetBasketQuery(string userId)
        {
            UserId = userId;
        }
    }
}
