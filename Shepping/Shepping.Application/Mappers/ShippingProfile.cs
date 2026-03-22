using AutoMapper;
using Shepping.Application.Commands;
using Shepping.Application.Responses;
using Shepping.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Mappers
{
    public class ShippingProfile: Profile
    {
        public ShippingProfile()
        {
            CreateMap<CreateShippingCommand, Shipping>().ReverseMap();
            CreateMap<UpdateShippingCommand, Shipping>().ReverseMap();
            CreateMap<Shipping, ShippingResponseDto>().ReverseMap();

        }
    }
}
