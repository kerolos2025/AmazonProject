using Baskets.Application.Commands;
using Baskets.Application.Queries;
using Baskets.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baskets.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IMediator mediator, ILogger<BasketController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetBasketByUserId")]
        public async Task<IActionResult> GetBasketByUserId(string userid)
        {
            var command = new GetBasketQuery(userid);

            var result = await _mediator.Send<BasketDTO>(command);
            if (result == null)
            {
                return Ok(Response<BasketDTO>.Fail("Basket not found", statusCode: 404));

            }
            return Ok(Response<BasketDTO>.SuccessResponse(result));
        }
        [HttpPost("CreateBasket")]
        public async Task<IActionResult> CreateBasket(CreateBasketCommand command)
        {
            

            var result = await _mediator.Send<bool>(command);
            if (result == false)
            {
                return Ok(Response<bool>.Fail("Error Occured", statusCode: 404));

            }
            return Ok(Response<bool>.SuccessResponse(result));
        }

        [HttpDelete("DeleteBasket")]
        public async Task<IActionResult> DeleteBasket(string userid)
        {
            var command = new DeleteBasketCommand(userid);

            var result = await _mediator.Send<bool>(command);
            if (result == false)
            {
                return Ok(Response<bool>.Fail("Error Occured", statusCode: 404));

            }
            return Ok(Response<bool>.SuccessResponse(result));
        }
    }
}
