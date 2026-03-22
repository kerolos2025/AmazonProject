using MediatR;
using Shepping.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Queries
{
    public class GetAllShippingQuery:IRequest<List<ShippingResponseDto>>
    {
    }
}
