namespace FlightBookings.Application.Models.Request
{
    public class CreateAirportRequest
    {
        public string Name { get; set; } = null!;

        public string City { get; set; } = null!;
    }

    public class UpdateAirportRequest : CreateAirportRequest
    {
        public Guid Id { get; set; }
    }
}
