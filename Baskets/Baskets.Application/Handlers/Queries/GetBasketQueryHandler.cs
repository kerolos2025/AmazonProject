using AutoMapper;
using Baskets.Application.Queries;
using Baskets.Application.Responses;
using Baskets.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Handlers.Queries
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketDTO>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public GetBasketQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<BasketDTO> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
           var basket=await  basketRepository.GetAsync<BasketDTO>(request.UserId);
            return basket;
        }
    }
}
