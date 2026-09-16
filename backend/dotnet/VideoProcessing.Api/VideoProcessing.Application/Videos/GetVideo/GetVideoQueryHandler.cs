using System;
using System.Collections.Generic;
using System.Text;
using VideoProcessing.Domain.Entities;

namespace VideoProcessing.Application.Videos.GetVideo
{
    public class GetVideoQueryHandler : IGetVideoQueryHandler
    {
        private readonly IVideoRepository _videoRepository;
        public GetVideoQueryHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public GetVideoResponse Handle(GetVideoQuery query)
        {
            var videoResponse = _videoRepository.GetVideoById(query.VideoId);
            return new GetVideoResponse
            {
                Id = videoResponse.Id,
                Name = videoResponse.Name,
                S3Key = videoResponse.S3Key,
            };
        }
    }
}
