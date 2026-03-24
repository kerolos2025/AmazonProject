using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Commands;
using Orders.Application.Queries;
using Orders.Application.Responses;

namespace Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IMediator mediator, ILogger<OrdersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var command = new GetOrderByIdQuery(id);

            var result = await _mediator.Send<OrderDTO>(command);
            if (result == null)
            {
                return Ok(Response<OrderDTO>.Fail("Order not found", statusCode: 404));

            }
            return Ok(Response<OrderDTO>.SuccessResponse(result));
        }

        [HttpGet("GetOrderByUserId")]
        public async Task<IActionResult> GetOrderByUserId(string id)
        {
            var command = new GetOrderByUserIdQuery(id);

            var result = await _mediator.Send<List<OrderDTO>>(command);
            if (result == null)
            {
                return Ok(Response<List<OrderDTO>>.Fail("Order not found", statusCode: 404));

            }
            return Ok(Response<List<OrderDTO>>.SuccessResponse(result));
        }
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
           

            var result = await _mediator.Send<OrderDTO>(command);
            if (result == null)
            {
                return Ok(Response<OrderDTO>.Fail("Error Occurred", statusCode: 404));

            }
            return Ok(Response<OrderDTO>.SuccessResponse(result));
        }
    }
}
