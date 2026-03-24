using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shepping.Application.Commands;
using Shepping.Application.Queries;
using Shepping.Application.Responses;
using System.Net;

namespace Shepping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ShippingController> _logger;

        public ShippingController(IMediator mediator, ILogger<ShippingController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]", Name = "GetAllShipping")]
        [ProducesResponseType(typeof(List<ShippingResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<ShippingResponseDto>>> GetAllShipping()
        {
            var query = new GetAllShippingQuery();
            var result = await _mediator.Send(query);
            
            return Ok(Response<List<ShippingResponseDto>>.SuccessResponse(result));
        }

        [HttpGet]
        [Route("[action]/{Id}", Name = "GetShippingById")]
        [ProducesResponseType(typeof(ShippingResponseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShippingResponseDto>> GetShippingById(string Id)
        {
            var query = new GetShippingByIdQuery(Id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return Ok(Response<ShippingResponseDto>.Fail("Error Occureed", statusCode: 404));

            }
            return Ok(Response<ShippingResponseDto>.SuccessResponse(result));
        }
        [HttpGet]
        [Route("[action]/{name}", Name = "GetShippingByName")]
        [ProducesResponseType(typeof(ShippingResponseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShippingResponseDto>> GetShippingByName(string name)
        {
            var query = new GetShippingByNameQuery(name);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return Ok(Response<ShippingResponseDto>.Fail("Error Occureed", statusCode: 404));

            }
            return Ok(Response<ShippingResponseDto>.SuccessResponse(result));
        }

        [HttpPost]
        [Route("[action]", Name = "CreateShipping")]

        [ProducesResponseType(typeof(ShippingResponseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShippingResponseDto>> CreateShipping([FromBody] CreateShippingCommand Command)
        {

            var result = await _mediator.Send<ShippingResponseDto>(Command);
            if (result == null)
            {
                return Ok(Response<ShippingResponseDto>.Fail("Error Occureed", statusCode: 404));

            }
            return Ok(Response<ShippingResponseDto>.SuccessResponse(result));
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateShipping([FromBody] UpdateShippingCommand Command)
        {

            var result = await _mediator.Send<bool>(Command);
            if (result == false)
            {
                return Ok(Response<bool>.Fail("Error Occureed", statusCode: 404));

            }
            return Ok(Response<bool>.SuccessResponse(result));
        }

        [HttpDelete]
        [Route("DeleteShippingItem")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            
            var command = new DeleteShippingCommand();
            command.Id = id;
            var result = await _mediator.Send<bool>(command);
            if (result == false)
            {
                return Ok(Response<bool>.Fail("Error Occureed", statusCode: 404));

            }
            return Ok(Response<bool>.SuccessResponse(result));
        }
    }
}
