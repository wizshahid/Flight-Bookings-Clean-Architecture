using FlightBookings.Domain.Enums;

namespace FlightBookings.Application.Models.Response
{
    public class AuthResponse
    {
        public string? Token { get; set; }

        public UserRole UserRole { get; set; }
        public Guid Id { get; internal set; }
    }
}
