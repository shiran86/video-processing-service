
namespace VideoProcessing.Application.Videos
{
    public interface IFileStorageService
    {
        Task<string> GetPresignedUrl(string key);
    }
}
