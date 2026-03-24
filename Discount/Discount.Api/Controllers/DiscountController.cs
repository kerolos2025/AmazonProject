using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DiscountController> _logger;

        public DiscountController(IMediator mediator, ILogger<DiscountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetDiscountById")]
        public async Task<IActionResult> GetDiscountById(int id)
        {
            var command = new GetDiscountByIdQuery(id);

            var result = await _mediator.Send<DiscountsDTO>(command);
            if (result == null)
            {
                return Ok(Response<DiscountsDTO>.Fail("Discount not found", statusCode: 404));

            }
            return Ok(Response<DiscountsDTO>.SuccessResponse(result));
        }
        [HttpGet("GetDiscountByProductId")]
        public async Task<IActionResult> GetDiscountByProductId(int productid)
        {
            var command = new GetDiscountByProductIdQuery(productid);

            var result = await _mediator.Send<DiscountsDTO>(command);
            if (result == null)
            {
                return Ok(Response<DiscountsDTO>.Fail("Discount not found", statusCode: 404));

            }
            return Ok(Response<DiscountsDTO>.SuccessResponse(result));
        }
        [HttpPost("CreateDiscount")]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCommand command)
        {

            var result = await _mediator.Send<DiscountsDTO>(command);
            if (result == null)
            {
                return Ok(Response<DiscountsDTO>.Fail("Error Occured at Creating Discount", statusCode: 404));

            }
            return Ok(Response<DiscountsDTO>.SuccessResponse(result));
        }

        [HttpDelete("DeleteDiscount")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var command = new DeleteDiscountCommand(id);
            var result = await _mediator.Send<bool>(command);
            if (result == false)
            {
                return Ok(Response<bool>.Fail("Error Occured at Deleting Discount", statusCode: 404));

            }
            return Ok(Response<bool>.SuccessResponse(result));
        }
    }
}
