namespace VideoProcessing.Application
{
    public interface IFileStorageService
    {
        Task<string> GetPresignedUrl(string key);
    }
}
