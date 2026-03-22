using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepping.Application.Commands
{
    public class DeleteShippingCommand:IRequest<bool>
    {
        public string Id { get; set; }
    }
}
