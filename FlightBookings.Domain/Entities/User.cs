using FlightBookings.Domain.Enums;

namespace FlightBookings.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Salt { get; set; } = null!;

        public string? ConfirmationCode { get; set; }

        public UserRole Role { get; set; }

        public UserStatus Status { get; set; }
    }
}
