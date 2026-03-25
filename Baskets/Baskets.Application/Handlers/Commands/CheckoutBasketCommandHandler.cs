using AutoMapper;
using Baskets.Application.Commands;
using Baskets.Core.Entities;
using Baskets.Core.Repositories;
using EventBus.Messages;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Handlers.Commands
{
    public class CheckoutBasketCommandHandler : IRequestHandler<CheckoutBasketCommand, bool>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CheckoutBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
            this._publishEndpoint= publishEndpoint;
        }

        public async Task<bool> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                    var basket =await basketRepository.GetAsync<Basket>(request.UserId);

                //rabbitMQ
                var basketEvent = new BasketCheckoutEvent() { 
                    UserId=basket.UserId,
                    UserName=basket.UserName,
                    Shipping =basket.Shipping,
                    TotalProductsPrice = basket.Items.Sum(item => item.Price * item.Count),
                    TotalPrice = basket.Items
                                .Sum(item => item.Price * item.Count) 
                                + (basket.Shipping.HasValue?basket.Shipping.Value:0)
                };

                await _publishEndpoint.Publish(basketEvent);


                var result= await basketRepository.DeleteAsync(request.UserId);

                    if (result)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

            }
            catch (Exception ex)
            {
                //log
                return false;
            }
        }
    }
}
