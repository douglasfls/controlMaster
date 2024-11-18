namespace ControlMaster.Providers;

internal interface IFileProvider
{
    Task<string> ReadAllText(string path, CancellationToken cancellationToken = default);
}

internal class FileProvider : IFileProvider
{
    public Task<string> ReadAllText(string path, CancellationToken cancellationToken = default) =>
        File.ReadAllTextAsync(path, cancellationToken);
}