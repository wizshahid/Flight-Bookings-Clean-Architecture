namespace FlightBookings.Domain.Enums;

public enum UserStatus : byte
{
    Active = 0,
    Inactive = 1,
}

public enum UserRole : byte
{
    User = 0,
    Admin = 1,
}

public enum AirlineStatus : byte
{
    Active = 0,
    Inactive = 1,
}
