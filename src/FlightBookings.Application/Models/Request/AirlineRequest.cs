using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookings.Application.Models.Request;

public class CreateAirlineRequest
{
    [Required]
    public string Name { get; set; } = null!;

    public string? ContactNo { get; set; }

    public string? ContactAddress { get; set; }

    [NotMapped]
    public IFormFile? File { get; set; }
}

public class UpdateAirlineRequest : CreateAirlineRequest
{
    public Guid Id { get; set; }
}
