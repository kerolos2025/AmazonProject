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
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, bool>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public CreateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            try
            { 
                var basket = mapper.Map<Basket>(request);
                await basketRepository.SetAsync(basket.UserId, basket);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
