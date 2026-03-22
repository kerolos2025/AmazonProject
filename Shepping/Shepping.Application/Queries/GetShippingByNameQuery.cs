using MediatR;
using Shepping.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Queries
{
    public class GetShippingByNameQuery :IRequest<ShippingResponseDto>
    {
        public string Name { get; set; }
        public GetShippingByNameQuery(string name)
        {
            this.Name = name;
        }
    }
}
