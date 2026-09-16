
namespace VideoProcessing.Application.Videos
{
    public interface IFileStorageService
    {
        string GetPresignedUrl(string key);
    }
}
