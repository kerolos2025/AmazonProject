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
    public class GetDiscountByIdQueryHandler : IRequestHandler<GetDiscountByIdQuery, DiscountsDTO>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public GetDiscountByIdQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<DiscountsDTO> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
           var item= await _discountRepository.GetByIdAsync(request.Id);
            if (item == null)
            {
                return null;
            }
            return _mapper.Map<DiscountsDTO>(item);
        }
    }
}
