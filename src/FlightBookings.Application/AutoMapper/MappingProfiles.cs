using AutoMapper;
using FlightBookings.Application.Models.Request;
using FlightBookings.Application.Models.Response;
using FlightBookings.Domain.Entities;

namespace FlightBookings.Application.AutoMapper;

internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<SignUpRequest, User>();
    }
}

internal class AirportMap : Profile
{
    public AirportMap()
    {
        CreateMap<CreateAirportRequest, Airport>();
        CreateMap<UpdateAirportRequest, Airport>();
        CreateMap<Airport, AirportResponse>();
    }
}

internal class AirlineMap : Profile
{
    public AirlineMap()
    {
        CreateMap<CreateAirlineRequest, Airline>();
        CreateMap<UpdateAirlineRequest, Airline>();
        CreateMap<Airline, AirlineResponse>();
    }
}

internal class InventoryMap : Profile
{
    public InventoryMap()
    {
        CreateMap<CreateInventoryRequest, Inventory>();
        CreateMap<UpdateInventoryRequest, Inventory>();
        CreateMap<Inventory, InventoryResponse>()
            .ForMember(x => x.FromPlace, y => y.MapFrom(z => z.FromPlace.Name))
            .ForMember(x => x.ToPlace, y => y.MapFrom(z => z.ToPlace.Name))
            .ForMember(x => x.AirlineName, y => y.MapFrom(z => z.Airline.Name));
    }
}
