using Microsoft.AspNetCore.Hosting;

namespace NexaCommerce.Infrastructure.Storage;

public sealed class LocalFileStorage : IFileStorage
{
    private readonly IWebHostEnvironment _environment;

    public LocalFileStorage(
        IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> SaveAsync(
        Stream stream,
        string fileName,
        CancellationToken cancellationToken = default)
    {
        var uploads =
            Path.Combine(
                _environment.WebRootPath,
                "uploads");

        if (!Directory.Exists(uploads))
            Directory.CreateDirectory(uploads);

        var path =
            Path.Combine(uploads, fileName);

        await using var file =
            File.Create(path);

        await stream.CopyToAsync(
            file,
            cancellationToken);

        return "/uploads/" + fileName;
    }

    public Task DeleteAsync(
        string fileName,
        CancellationToken cancellationToken = default)
    {
        var path =
            Path.Combine(
                _environment.WebRootPath,
                "uploads",
                fileName);

        if (File.Exists(path))
            File.Delete(path);

        return Task.CompletedTask;
    }
}
