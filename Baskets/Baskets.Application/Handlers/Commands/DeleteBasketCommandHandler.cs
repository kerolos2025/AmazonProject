using Baskets.Application.Commands;
using Baskets.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Handlers.Commands
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, bool>
    {
        private readonly IBasketRepository basketRepository;

        public DeleteBasketCommandHandler(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await basketRepository.DeleteAsync(request.UserId);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
           
        }
    }
}
