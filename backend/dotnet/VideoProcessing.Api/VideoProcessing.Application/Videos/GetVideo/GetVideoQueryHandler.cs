using System;
using System.Collections.Generic;
using System.Text;
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

        public GetVideoResponse Handle(GetVideoQuery query)
        {
            var videoResponse = _videoRepository.GetVideoById(query.VideoId);
            Version preSignedUrl = _fileStorageService.GetPresignedUrl();

            return new GetVideoResponse
            {
                Id = videoResponse.Id,
                Name = videoResponse.Name,
                S3Key = videoResponse.S3Key,
            };
        }
    }
}
