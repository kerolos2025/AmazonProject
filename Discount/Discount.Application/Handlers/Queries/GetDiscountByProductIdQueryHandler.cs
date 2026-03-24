using AutoMapper;
using Discount.Application.Queries;
using Discount.Application.Responses;
using Discount.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handlers.Queries
{
    public class GetDiscountByProductIdQueryHandler : IRequestHandler<GetDiscountByProductIdQuery, DiscountsDTO>
    {
        private readonly IDiscountRepository discountRepository;
        private readonly IMapper mapper;

        public GetDiscountByProductIdQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            this.discountRepository = discountRepository;
            this.mapper = mapper;
        }

        public async Task<DiscountsDTO> Handle(GetDiscountByProductIdQuery request, CancellationToken cancellationToken)
        {
            var discount = await discountRepository.GetByProductIdAsync(request.ProductId);
            if (discount == null)
            {
                return null;
            }
            return mapper.Map<DiscountsDTO>(discount);
        }
    }
}
