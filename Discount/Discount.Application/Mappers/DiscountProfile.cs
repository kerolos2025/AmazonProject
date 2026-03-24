using AutoMapper;
using Discount.Application.Commands;
using Discount.Application.Responses;
using Discount.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Mappers
{
    public class DiscountProfile:Profile
    {
        public DiscountProfile()
        {
            CreateMap<DiscountsDTO, Discounts>().ReverseMap();
            CreateMap<CreateDiscountCommand, Discounts>().ReverseMap();
        }
    }
}
