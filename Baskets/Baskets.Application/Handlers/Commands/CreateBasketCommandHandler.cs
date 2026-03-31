using AutoMapper;
using Baskets.Application.Commands;
using Baskets.Application.GrpcServices;
using Baskets.Core.Entities;
using Baskets.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Handlers.Commands
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, bool>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;
        private readonly DiscountGrpcService _discountGrpcService;

        public CreateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper
            , DiscountGrpcService discountGrpcService)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
            this._discountGrpcService = discountGrpcService;
        }

        public async Task<bool> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            try
            { 
                var basket = mapper.Map<Basket>(request);

                foreach (var item in basket.Items)
                {
                    var coupon = await _discountGrpcService.GetDiscount(item.ProductId);
                    if(coupon != null && coupon.Percentage!=null && coupon.Percentage!=0)
                        item.Price =(item.Price * coupon.Percentage)/100;
                }
                await basketRepository.SetAsync(basket.UserId, basket);
                return true;
            }catch(Exception ex)
            {
                var folder = @"C:\inetpub\wwwroot\basketService\Logs";
                Directory.CreateDirectory(folder); // مهم جدًا
                var path= Path.Combine(folder, "log.txt");
                var log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.InnerException.Message+ex.StackTrace}{Environment.NewLine}";
                File.AppendAllText(path, log, Encoding.UTF8);
                return false;
            }
        }
    }
}
