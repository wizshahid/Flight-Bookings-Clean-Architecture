using AutoMapper;
using AutoMapper.QueryableExtensions;
using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Models.Request;
using FlightBookings.Application.Models.Response;
using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Interfaces;

namespace FlightBookings.Application.Services;
public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository repository;
    private readonly IMapper mapper;

    public InventoryService(IInventoryRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public InventoryResponse Add(CreateInventoryRequest inventoryRequest)
    {
        if (repository.Any(x => x.FlightNumber == inventoryRequest.FlightNumber))
            throw new ApplicationException("Flight Number Already Exists");

        var inventory = mapper.Map<Inventory>(inventoryRequest);
        repository.Add(inventory);

        return GetItem(inventory.Id);
    }

    public void Delete(Guid id)
    {
        //if(booking exists) throw AppException
        repository.Delete(id);
    }

    public InventoryResponse GetItem(Guid id)
    {
        return repository.GetAll(x => x.Id == id).ProjectTo<InventoryResponse>(mapper.ConfigurationProvider).First();
    }

    public List<InventoryResponse> GetList()
    {
        return repository.GetAll().ProjectTo<InventoryResponse>(mapper.ConfigurationProvider).ToList();
    }

    public InventoryResponse Update(UpdateInventoryRequest inventoryRequest)
    {
        if (repository.Any(x => x.FlightNumber == inventoryRequest.FlightNumber && x.Id != inventoryRequest.Id))
            throw new ApplicationException("Flight Number Already Exists");

        var inventory = mapper.Map<Inventory>(inventoryRequest);
        repository.Update(inventory);

        return GetItem(inventory.Id);
    }
}
