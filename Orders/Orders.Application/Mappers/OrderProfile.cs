using AutoMapper;
using EventBus.Messages;
using Orders.Application.Commands;
using Orders.Application.Responses;
using Orders.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Mappers
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<BasketCheckoutEvent, Order>().ReverseMap();
        }
    }
}
