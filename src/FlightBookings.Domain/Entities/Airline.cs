using FlightBookings.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlightBookings.Domain.Entities;

public class Airline
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? ContactNo { get; set; }

    public string? ContactAddress { get; set; }

    public string? LogoPath { get; set; }

    public AirlineStatus Status { get; set; }
}
