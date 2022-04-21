using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookings.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService service;

    public InventoryController(IInventoryService inventoryService)
    {
        this.service = inventoryService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateInventoryRequest inventoryRequest)
    {
        var result = service.Add(inventoryRequest);
        var uri = Request.Scheme + "://" + Request.Host + Request.Path + "/" + result.Id;
        return Created(uri, result);
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(service.GetItem(id));
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(service.GetList());
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        service.Delete(id);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromForm] UpdateInventoryRequest inventoryRequest)
    {
        return Ok(service.Update(inventoryRequest));
    }
}
