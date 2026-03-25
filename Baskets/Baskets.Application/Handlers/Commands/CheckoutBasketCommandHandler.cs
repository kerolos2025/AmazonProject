using AutoMapper;
using Baskets.Application.Commands;
using Baskets.Core.Entities;
using Baskets.Core.Repositories;
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

        public CheckoutBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                    var basket =await basketRepository.GetAsync<Basket>(request.UserId);
                    //rabbitMQ

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
