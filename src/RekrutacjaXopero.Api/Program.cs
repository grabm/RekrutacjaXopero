
using RekrutacjaXopero.Api.Configuration;
using RekrutacjaXopero.Api.Middleware;
using RekrutacjaXopero.Logic.Constans;

namespace RekrutacjaXopero.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            var httpClientUrls = builder.Configuration.GetSection(nameof(HttpClientUrls)).Get<HttpClientUrls>();
            var issuePlatformCredentials = builder.Configuration.GetSection(nameof(IssuePlatformCredentials)).Get<IssuePlatformCredentials>();

            builder.Services.AddHttpClient(HttpClientNames.GitHub, httpClient =>
            {
                httpClient.BaseAddress = new Uri(httpClientUrls.GitHub);
                httpClient.DefaultRequestHeaders.Add(issuePlatformCredentials.GitHubAccessTokenHeaderName, issuePlatformCredentials.GitHubAccessToken);
            });

            builder.Services.AddHttpClient(HttpClientNames.GitLab, httpClient =>
            {
                httpClient.BaseAddress = new Uri(httpClientUrls.GitLab);
                httpClient.DefaultRequestHeaders.Add(issuePlatformCredentials.GitLabAccessTokenHeaderName, issuePlatformCredentials.GitLabAccessToken);
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
