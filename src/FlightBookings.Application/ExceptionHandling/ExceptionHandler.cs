using FlightBookings.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace FlightBookings.Application.ExceptionHandling;

public class ExceptionHandler
{
    public static async Task Handle(HttpContext context)
    {
        var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
        var message = exception?.Message;

        switch (exception)
        {
            case AppException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            default:
                break;
        }

        await context.Response.WriteAsync(message);
    }
}
