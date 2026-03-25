using AutoMapper;
using EventBus.Messages;
using MassTransit;
using Orders.Core.Entities;
using Orders.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Consumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public BasketCheckoutConsumer(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var message = context.Message;

            // Map BasketCheckoutEvent -> Order entity
           
            var order = _mapper.Map<Order>(message);
            await _orderRepository.AddAsync(order);
           

            Console.WriteLine($"Order created for basket {message.UserId}");
        }
    }
}
