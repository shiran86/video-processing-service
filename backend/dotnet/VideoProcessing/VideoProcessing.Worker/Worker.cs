using Amazon.SQS;
using Amazon.SQS.Model;
using System.Numerics;

namespace VideoProcessing.Worker
{
    public class Worker(ILogger<Worker> logger,
    IAmazonSQS amazonSQS,
    IConfiguration configuration) : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // 1. קבלת Message מ-SQS

                // 2. המרת ה-Message ל-CreateClipCommand

                // 3. Log של הפרטים שקיבלנו


                var request = new ReceiveMessageRequest
                {
                    QueueUrl = configuration["AWSSettings:SqsQueueUrl"],
                    MaxNumberOfMessages = 1,
                    WaitTimeSeconds = 20
                };

                var response = await amazonSQS.ReceiveMessageAsync(request, stoppingToken);
                if (response.Messages?.Any() != true)
                {
                    continue;
                }

                var message = response.Messages[0];
                // 4. "עיבוד" מדומה
                await Task.Delay(3000, stoppingToken);
                await amazonSQS.DeleteMessageAsync(configuration["AWSSettings:SqsQueueUrl"], message.ReceiptHandle, stoppingToken);

                // 5. הודעה שהעיבוד הסתיים
                // await notificationService.NotifyProcessingCompletedAsync(...);
            }
        }
    }
}
