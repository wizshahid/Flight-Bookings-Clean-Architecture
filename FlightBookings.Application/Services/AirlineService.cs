using AutoMapper;
using AutoMapper.QueryableExtensions;
using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Models.Request;
using FlightBookings.Application.Models.Response;
using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Exceptions;
using FlightBookings.Domain.Interfaces;

namespace FlightBookings.Application.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository repository;
        private readonly IFileService fileService;
        private readonly IMapper mapper;

        public AirlineService(IAirlineRepository airlineRepository, IFileService fileService, IMapper mapper)
        {
            this.repository = airlineRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }

        public async Task<AirlineResponse> Add(CreateAirlineRequest airlineRequest)
        {
            if (repository.Any(x => x.Name == airlineRequest.Name))
                throw new AppException($"Airline with name {{{airlineRequest.Name}}} already exists");

            var airline = mapper.Map<Airline>(airlineRequest);

            if (airlineRequest.File is not null)
            {
                airline.LogoPath = await fileService.UploadFileAsync(airlineRequest.File);
            }

            repository.Add(airline);
            return mapper.Map<AirlineResponse>(airline);
        }

        public async Task Delete(Guid id)
        {
            var airline = repository.GetById(id);

            if (airline is null)
                throw new AppException("Invalid Id");

            if (airline.LogoPath is not null)
                await fileService.DeleteFileAsync(airline.LogoPath);

            repository.Delete(id);
        }

        public List<AirlineResponse> GetAirlines()
        {
            return repository.GetAll().ProjectTo<AirlineResponse>(mapper.ConfigurationProvider).ToList();
        }

        public AirlineResponse GetById(Guid id)
        {
            return mapper.Map<AirlineResponse>(repository.GetById(id));
        }

        public async Task<AirlineResponse> Update(UpdateAirlineRequest airlineRequest)
        {
            if (repository.Any(x => x.Id != airlineRequest.Id && x.Name == airlineRequest.Name))
                throw new AppException($"Airline with name {{{airlineRequest.Name}}} already exists");

            Airline airline = mapper.Map<Airline>(airlineRequest);

            var dbAirline = repository.GetById(airlineRequest.Id);

            if (dbAirline is null)
                throw new AppException("Airplane does not exist");

            if (airlineRequest.File is not null)
            {
                if (dbAirline.LogoPath is not null)
                    await fileService.DeleteFileAsync(dbAirline.LogoPath);

                airline.LogoPath = await fileService.UploadFileAsync(airlineRequest.File);
            }
            else
                airline.LogoPath = dbAirline.LogoPath;

            repository.Update(airline);

            return mapper.Map<AirlineResponse>(airline);
        }
    }
}
