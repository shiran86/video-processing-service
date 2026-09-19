using Amazon.S3;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using VideoProcessing.Application.Clips.CreateClips;
using VideoProcessing.Application.Messaging;
namespace VideoProcessing.Infrastructure.Messaging
{
    public class SqsClipProcessingMessageQueue : IClipProcessingQueue
    {
        private readonly IAmazonSQS _amazonSQS;
        private readonly IConfiguration _configuration;

        public SqsClipProcessingMessageQueue(IAmazonSQS amazonSQS, IConfiguration configuration )
        {
            _amazonSQS = amazonSQS;
            this._configuration = configuration;
        }

        public async Task EnqueueAsync(CreateClipCommand command)
        {
            var request = new SendMessageRequest {
                QueueUrl = _configuration["AWSSettings:SqsQueueUrl"],
                MessageBody = JsonSerializer.Serialize(command)
            };

            var response = await _amazonSQS.SendMessageAsync(request);
            var a = "";
        }
    }
}
