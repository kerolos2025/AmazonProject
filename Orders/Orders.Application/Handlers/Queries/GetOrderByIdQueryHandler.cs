using AutoMapper;
using MediatR;
using Orders.Application.Queries;
using Orders.Application.Responses;
using Orders.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Handlers.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var item=await orderRepository.GetByIdAsync(request.Id);
            var order = mapper.Map<OrderDTO>(item);
            return order;
        }
    }
}
