﻿namespace FlightBookings.Application.Models.Request
{
    public class SignUpRequest
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
    }
}