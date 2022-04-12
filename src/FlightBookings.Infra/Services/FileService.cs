using FlightBookings.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FlightBookings.Infra.Services;

internal class FileService : IFileService
{
    private readonly string webRootPath;

    public FileService(string webRootPath)
    {
        this.webRootPath = webRootPath;
    }


    public async Task DeleteFileAsync(string fileName)
    {
        await Task.Run(() => File.Delete(Path.Combine(webRootPath, fileName)));
    }


    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var path = Path.Combine("Files", Guid.NewGuid() + file.FileName);
        using FileStream fs = new(Path.Combine(webRootPath, path), FileMode.Create);
        await file.CopyToAsync(fs);
        return path;
    }
}
