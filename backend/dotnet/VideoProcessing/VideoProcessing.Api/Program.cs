using Amazon;
using Amazon.S3;
using Amazon.SQS;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using VideoProcessing.Application.Clips.CreateClips;
using VideoProcessing.Application.Messaging;
using VideoProcessing.Application.Storage;
using VideoProcessing.Application.Videos;
using VideoProcessing.Application.Videos.GetVideo;
using VideoProcessing.Infrastructure.Messaging;
using VideoProcessing.Infrastructure.Repositories;
using VideoProcessing.Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IGetVideoQueryHandler, GetVideoQueryHandler>();
builder.Services.AddScoped<IFileStorageService, S3FileStorageService>();
builder.Services.AddScoped<IAmazonS3>(_ => new AmazonS3Client(RegionEndpoint.USEast1));
builder.Services.AddScoped<IAmazonSQS>(_ => new AmazonSQSClient(RegionEndpoint.USEast1));

builder.Services.AddScoped<IClipProcessingQueue, SqsClipProcessingMessageQueue>();


builder.Services.AddScoped<ICreateClipCommandHandler, CreateClipCommandHandler>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie((options) =>
    {
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    }).AddOpenIdConnect(options =>
    {
        options.Authority = builder.Configuration["OpenIDConnectSettings:Authority"]; // Cognito User Pool 
        options.ClientId = builder.Configuration["OpenIDConnectSettings:ClientId"];
        options.ClientSecret = builder.Configuration["OpenIDConnectSettings:ClientSecret"];
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.UsePkce = true;
        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("email");

        //options.SaveTokens = true;
    }); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("Frontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
