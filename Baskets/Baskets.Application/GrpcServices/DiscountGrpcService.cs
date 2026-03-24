using Discount.Grpc.Protos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountGrpcClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountGrpcClient)
        {
            _discountGrpcClient = discountGrpcClient;
        }
        public async Task<CouponModel?> GetDiscount(int productId)
        {
            var discountRequest = new GetDiscountRequest { ProductId = productId };
            try
            {
                return await _discountGrpcClient.GetDiscountAsync(discountRequest);
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                // Discount service returned NotFound for this product - treat as no discount
                return null;
            }
        }
    }
}
