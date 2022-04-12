using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookings.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AirportController : ControllerBase
{
    private readonly IAirportService service;

    public AirportController(IAirportService service)
    {
        this.service = service;
    }

    [HttpPost]
    public IActionResult Post(CreateAirportRequest airportRequest)
    {
        var result = service.Add(airportRequest);
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
        return Ok(service.GetAirports());
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        service.Delete(id);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put(UpdateAirportRequest airportRequest)
    {
        return Ok(service.Update(airportRequest));
    }
}
