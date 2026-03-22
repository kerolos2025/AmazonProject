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
    public class GetShippingByIdQueryHandler : IRequestHandler<GetShippingByIdQuery, ShippingResponseDto>
    {
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;
        public GetShippingByIdQueryHandler(IShippingRepository shippingRepository, IMapper mapper)
        {
            this._shippingRepository = shippingRepository;
            this._mapper = mapper;
        }
        public async Task<ShippingResponseDto> Handle(GetShippingByIdQuery request, CancellationToken cancellationToken)
        {
           var item=await _shippingRepository.GetShippingById(request.Id);
            if (item == null)
            {
                return null;
            }
            var result = _mapper.Map<ShippingResponseDto>(item);
            return result;
        }
    }
}
