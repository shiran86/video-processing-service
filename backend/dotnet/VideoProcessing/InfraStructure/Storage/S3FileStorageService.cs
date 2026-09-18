using Amazon.S3;
using Amazon.S3.Model;
using VideoProcessing.Application;

namespace VideoProcessing.Infrastructure.Storage
{
    public class S3FileStorageService : IFileStorageService
    {
        private readonly IAmazonS3 _s3Client;
        public S3FileStorageService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<string> GetPresignedUrl(string key)
        {
            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest {
                BucketName = "video-processing-shiran",
                Key = key,
                Expires = DateTime.UtcNow.AddHours(1)
            };

            string presignUrl = await _s3Client.GetPreSignedURLAsync(request);
            return presignUrl;
        }
    }
}
