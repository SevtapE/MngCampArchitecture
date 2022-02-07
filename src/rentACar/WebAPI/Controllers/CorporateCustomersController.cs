using Application.Features.CorporateCustomers.Commands;
using Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer;
using Application.Features.CorporateCustomers.DeleteCorporateCustomer;
using Application.Features.CorporateCustomers.Queries;
using Core.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateCustomersController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCorporateCustomerCommand createIndividualCustomerCommand)
        {
            var result = await Mediator.Send(createIndividualCustomerCommand);
            return Created("", result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand updateIndividualCustomerCommand)
        {
            var result = await Mediator.Send(updateIndividualCustomerCommand);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCorporateCustomerCommand deleteIndividualCustomerCommand)
        {
            var result = await Mediator.Send(deleteIndividualCustomerCommand);
            return Ok(result);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCorporateCustomerListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
