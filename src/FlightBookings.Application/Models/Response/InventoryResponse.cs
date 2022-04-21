using FlightBookings.Application.Models.Request;

namespace FlightBookings.Application.Models.Response;
public class InventoryResponse : UpdateInventoryRequest
{
    public string AirlineName { get; set; } = null!;

    public string FromPlace { get; set; } = null!;

    public string ToPlace { get; set; } = null!;
}
