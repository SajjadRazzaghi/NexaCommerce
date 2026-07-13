namespace NexaCommerce.Infrastructure.Storage;

public interface IFileStorage
{
    Task<string> SaveAsync(
        Stream stream,
        string fileName,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        string fileName,
        CancellationToken cancellationToken = default);
}
