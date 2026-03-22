using AutoMapper;
using MediatR;
using Shepping.Application.Queries;
using Shepping.Application.Responses;
using Shepping.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Handlers.Queries
{
    public class GetShippingByNameQueryHandler : IRequestHandler<GetShippingByNameQuery, ShippingResponseDto>
    {
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;

        public GetShippingByNameQueryHandler(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<ShippingResponseDto> Handle(GetShippingByNameQuery request, CancellationToken cancellationToken)
        {
            var item = await _shippingRepository.GetShippingByName(request.Name);
            var result = _mapper.Map<ShippingResponseDto>(item);
            return result;
        }
    }
}
