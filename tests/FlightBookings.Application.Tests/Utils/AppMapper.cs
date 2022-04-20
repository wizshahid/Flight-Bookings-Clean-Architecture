using AutoMapper;
using FlightBookings.Application.AutoMapper;

namespace FlightBookings.Application.Tests.Utils;
internal class AppMapper
{
    internal static IMapper GetMapper()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddMaps(typeof(IAutoMapperMarker));
        });
        IMapper mapper = mappingConfig.CreateMapper();
        return mapper;
    }
}
