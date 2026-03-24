using AutoMapper;
using Discount.Application.Commands;
using Discount.Application.Responses;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handlers.Commands
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, DiscountsDTO>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public CreateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<DiscountsDTO> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Discounts>(request);
            var result =await _discountRepository.AddAsync(item);
            var itemDTO = _mapper.Map<DiscountsDTO>(result);
            return itemDTO;

        }
    }
}
