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

public enum Meals : short
{
    None = 0,
    Veg = 1,
    NonVeg = 2,
    Both = 3,
}

public enum BookingStatus : short
{
    Success = 0,
    Cancel = 1
}

public enum ScheduledDays : short
{
    Daily = 0,
    WeekDays = 1,
    WeekEnds = 2,
    SpecificDays = 4,
}

public enum FlightType
{
    Oneway,
    RoundTrip
}
