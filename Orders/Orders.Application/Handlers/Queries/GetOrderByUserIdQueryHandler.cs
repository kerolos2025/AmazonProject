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
    public class GetOrderByUserIdQueryHandler : IRequestHandler<GetOrderByUserIdQuery, List<OrderDTO>>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public GetOrderByUserIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<List<OrderDTO>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetByUserId(request.UserId);
            return mapper.Map<List<OrderDTO>>(orders);
        }
    }
}
