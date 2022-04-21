using FlightBookings.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlightBookings.Application.Models.Request;
public class CreateInventoryRequest
{
    public Guid AirlineId { get; set; }

    [Required]
    public string FlightNumber { get; set; } = null!;

    public Guid FromPlaceId { get; set; }

    public Guid ToPlaceId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public ScheduledDays ScheduledDays { get; set; }

    [Required]
    public string InstrumentUsed { get; set; } = null!;

    [Range(1, 100)]
    public int BusinessClassSeats { get; set; }

    [Range(1, 100)]
    public int NonBusinessClassSeats { get; set; }

    [Range(1, 10000)]
    public int TicketPrice { get; set; }

    [Range(1, 100)]
    public int NumberOfRows { get; set; }

    public Meals Meals { get; set; }
}

public class UpdateInventoryRequest : CreateInventoryRequest
{
    public Guid Id { get; set; }
}
