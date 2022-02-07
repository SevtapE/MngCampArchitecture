using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Queries.GetBrandList;
using Application.Features.Cars.Commands;
using Application.Features.Cars.Commands.CreateCars;
using Application.Features.Cars.Commands.DeleteCars;
using Application.Features.Cars.Commands.UpdateCars;
using Application.Features.Cars.Queries.GetBrandList;
using Core.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody ] CreateCarCommand createCarCommand)
        {
            var result = await Mediator.Send(createCarCommand);
            return Created("", result);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
           
            var query = new GetCarListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand uptadeCarCommand)
        {
            var result = await Mediator.Send(uptadeCarCommand);
            return Ok(result);
        }

        [HttpPut("rent")]
        public async Task<IActionResult> Rent([FromBody] RentCarCommand rentCarCommand)
        {
            var result = await Mediator.Send(rentCarCommand);
            return Ok(result);
        }

        [HttpPut("maintenance")]
        public async Task<IActionResult> Maintenance([FromBody] MaintenanceCarCommand maintenanceCarCommand)
        {
            var result = await Mediator.Send(maintenanceCarCommand);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand deleteCarCommand)
        {
            var result = await Mediator.Send(deleteCarCommand);
            return Ok(result);
        }
    }
}
