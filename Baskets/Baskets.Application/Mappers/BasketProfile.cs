using AutoMapper;
using Baskets.Application.Commands;
using Baskets.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Mappers
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, CreateBasketCommand>().ReverseMap();
        }
    }
}
