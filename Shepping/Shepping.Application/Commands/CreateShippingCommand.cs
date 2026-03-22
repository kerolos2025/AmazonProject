using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using Shepping.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Commands
{
    public class CreateShippingCommand : IRequest<ShippingResponseDto>
    {
        public string Name { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]

        public decimal Price { get; set; }
    }
}
