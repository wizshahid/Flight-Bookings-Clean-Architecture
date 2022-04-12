using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookings.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class AirlineController : ControllerBase
{
    private readonly IAirlineService service;

    public AirlineController(IAirlineService service)
    {
        this.service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateAirlineRequest airplaneRequest)
    {
        var result = await service.Add(airplaneRequest);
        var uri = Request.Scheme + "://" + Request.Host + Request.Path + "/" + result.Id;
        return Created(uri, result);
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(service.GetById(id));
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(service.GetAirlines());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await service.Delete(id);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromForm] UpdateAirlineRequest airlineRequest)
    {
        return Ok(await service.Update(airlineRequest));
    }
}
