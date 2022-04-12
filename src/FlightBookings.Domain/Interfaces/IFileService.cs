using Microsoft.AspNetCore.Http;

namespace FlightBookings.Domain.Interfaces;

public interface IFileService
{
    Task<string> UploadFileAsync(IFormFile file);

    Task DeleteFileAsync(string fileName);
}
