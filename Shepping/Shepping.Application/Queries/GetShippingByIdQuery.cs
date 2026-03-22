using MediatR;
using Shepping.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Queries
{
    public class GetShippingByIdQuery:IRequest<ShippingResponseDto>
    {
        public string Id { get; set; }
        public GetShippingByIdQuery(string id)
        {
            this.Id = id;
        }
    }
}
