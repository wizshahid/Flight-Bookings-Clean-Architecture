using FlightBookings.Api.DependencyInjection;
using FlightBookings.Application.ExceptionHandling;
using FlightBookings.Infra.Data.Context;
using FlightBookings.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.RegisterServices(builder.Configuration, builder.Environment.WebRootPath);
builder.Services.AddSwagger()
                .AddJwtAuthentication(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = ExceptionHandler.Handle
});

app.MapControllers();

app.Run();