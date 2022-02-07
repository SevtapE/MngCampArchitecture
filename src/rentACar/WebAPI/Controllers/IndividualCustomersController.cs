using Application.Features.IndividualCustomers.Commands;
using Application.Features.IndividualCustomers.Queries;
using Core.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomersController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateIndividualCustomerCommand createIndividualCustomerCommand)
        {
            var result = await Mediator.Send(createIndividualCustomerCommand);
            return Created("", result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerCommand updateIndividualCustomerCommand)
        {
            var result = await Mediator.Send(updateIndividualCustomerCommand);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteIndividualCustomerCommand deleteIndividualCustomerCommand)
        {
            var result = await Mediator.Send(deleteIndividualCustomerCommand);
            return Ok(result);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetIndividualCustomerListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
