using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Api.Service
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IMediator _mediator;

        public DiscountService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var query = new GetDiscountByProductIdQuery(request.ProductId);
            var result = await _mediator.Send(query);
            if (result==null)
            {
                return new CouponModel();
            }
            CouponModel coupon=new CouponModel
            {
                ProductId = result.ProductId,
                Percentage = result.Percentage
            };
            return coupon;
        }
       
    }
}
