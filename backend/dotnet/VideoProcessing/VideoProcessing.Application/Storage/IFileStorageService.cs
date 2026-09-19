namespace VideoProcessing.Application.Storage
{
    public interface IFileStorageService
    {
        Task<string> GetPresignedUrl(string key);
    }
}
