using Amazon;
using Amazon.SQS;
using VideoProcessing.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IAmazonSQS>(_ => new AmazonSQSClient(RegionEndpoint.USEast1));
var host = builder.Build();
host.Run();
