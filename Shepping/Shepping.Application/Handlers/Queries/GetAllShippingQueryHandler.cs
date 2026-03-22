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
    public class GetAllShippingQueryHandler : IRequestHandler<GetAllShippingQuery, List<ShippingResponseDto>>
    {
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;

        public GetAllShippingQueryHandler(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<List<ShippingResponseDto>> Handle(GetAllShippingQuery request, CancellationToken cancellationToken)
        {
           var shippings = await _shippingRepository.GetAllShipping();
            var shippingDtos = _mapper.Map<List<ShippingResponseDto>>(shippings);
            return shippingDtos;
        }
    }
}
