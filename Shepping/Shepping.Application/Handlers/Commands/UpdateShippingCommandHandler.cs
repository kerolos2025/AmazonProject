using AutoMapper;
using MediatR;
using Shepping.Application.Commands;
using Shepping.Core.Entities;
using Shepping.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Handlers.Commands
{
    public class UpdateShippingCommandHandler : IRequestHandler<UpdateShippingCommand, bool>
    {
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;

        public UpdateShippingCommandHandler(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateShippingCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Shipping>(request);
            return await _shippingRepository.UpdateShipping(item);
        }
    }
}
