using AutoMapper;
using MediatR;
using Shepping.Application.Commands;
using Shepping.Application.Responses;
using Shepping.Core.Entities;
using Shepping.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Handlers.Commands
{
    public class CreateShippingCommandHandler : IRequestHandler<CreateShippingCommand, ShippingResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IShippingRepository _shippingRepository;

        public CreateShippingCommandHandler(IMapper mapper, IShippingRepository shippingRepository)
        {
            _mapper = mapper;
            _shippingRepository = shippingRepository;
        }

        public async Task<ShippingResponseDto> Handle(CreateShippingCommand request, CancellationToken cancellationToken)
        {
            var shipping = _mapper.Map<Shipping>(request);
            var item=await  _shippingRepository.CreateShipping(shipping);
            var result = _mapper.Map<ShippingResponseDto>(item);
            return result;

        }
    }
}
