using FlightBookings.Application.Models.Request;
using FlightBookings.Application.Models.Response;

namespace FlightBookings.Application.Interfaces
{
    public interface IUserService
    {
        void SignUp(SignUpRequest model);

        AuthResponse Login(LoginRequest model);
    }
}
