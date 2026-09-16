using System;
using System.Collections.Generic;
using System.Text;
using VideoProcessing.Domain.Enums;

namespace VideoProcessing.Application.Videos.GetVideo
{
    public record GetVideoResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string S3Key { get; set; } = string.Empty;

        public string PreSignedUrl { get; set; } = string.Empty;

    }
}
