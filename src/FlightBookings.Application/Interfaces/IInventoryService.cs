using FlightBookings.Application.Models.Request;
using FlightBookings.Application.Models.Response;

namespace FlightBookings.Application.Interfaces;
public interface IInventoryService
{
    InventoryResponse Add(CreateInventoryRequest inventoryRequest);

    InventoryResponse Update(UpdateInventoryRequest inventoryRequest);

    InventoryResponse GetItem(Guid id);

    void Delete(Guid id);

    List<InventoryResponse> GetList();
}
