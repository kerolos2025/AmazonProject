using AutoMapper;
using MediatR;
using Orders.Application.Commands;
using Orders.Application.Responses;
using Orders.Core.Entities;
using Orders.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Handlers.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var item = mapper.Map<Order>(request);
            var order=await orderRepository.AddAsync(item);
            return mapper.Map<OrderDTO>(order);
        }
    }
}
