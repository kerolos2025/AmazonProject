using MediatR;
using Shepping.Application.Commands;
using Shepping.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Handlers.Commands
{
    public class DeleteShippingCommandHandler : IRequestHandler<DeleteShippingCommand, bool>
    {
        private readonly IShippingRepository _shippingRepository;

        public DeleteShippingCommandHandler(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        public async Task<bool> Handle(DeleteShippingCommand request, CancellationToken cancellationToken)
        {
           var result=  await _shippingRepository.DeleteShipping(request.Id);
            return result;
        }
    }
}
