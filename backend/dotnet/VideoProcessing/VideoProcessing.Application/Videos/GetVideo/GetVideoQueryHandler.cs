using System;
using System.Collections.Generic;
using System.Text;
using VideoProcessing.Application.Storage;
using VideoProcessing.Domain.Entities;

namespace VideoProcessing.Application.Videos.GetVideo
{
    public class GetVideoQueryHandler : IGetVideoQueryHandler
    {
        private readonly IVideoRepository _videoRepository;

        private readonly IFileStorageService _fileStorageService;

        public GetVideoQueryHandler(IVideoRepository videoRepository, IFileStorageService fileStorageService)
        {
            _videoRepository = videoRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<GetVideoResponse> Handle(GetVideoQuery query)
        {
            var videoResponse = await _videoRepository.GetVideoByIdAsync(query.VideoId);
            string preSignedUrl = await _fileStorageService.GetPresignedUrl(videoResponse.S3Key);

            return new GetVideoResponse
            {
                Id = videoResponse.Id,
                Name = videoResponse.Name,
                S3Key = videoResponse.S3Key,
                PreSignedUrl = preSignedUrl,
            };
        }
    }
}
