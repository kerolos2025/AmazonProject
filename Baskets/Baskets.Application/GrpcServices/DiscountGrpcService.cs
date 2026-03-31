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
                var folder = @"C:\inetpub\wwwroot\basketService\Logs";
                Directory.CreateDirectory(folder); // مهم جدًا
                var path = Path.Combine(folder, "log.txt");
                var log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.InnerException.Message + ex.StackTrace}{Environment.NewLine}";
                File.AppendAllText(path, log, Encoding.UTF8);
                // Discount service returned NotFound for this product - treat as no discount
                return null;
            }
        }
    }
}
