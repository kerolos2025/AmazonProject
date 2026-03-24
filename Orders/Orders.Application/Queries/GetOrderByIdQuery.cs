using MediatR;
using Orders.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Queries
{
    public class GetOrderByIdQuery:IRequest<OrderDTO>
    {
        public int Id { get; set; }
        public GetOrderByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
