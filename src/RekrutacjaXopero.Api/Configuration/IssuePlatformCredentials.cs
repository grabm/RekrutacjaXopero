namespace RekrutacjaXopero.Api.Configuration;

public record IssuePlatformCredentials(
    string GitHubAccessTokenHeaderName,
    string GitHubAccessToken,
    string GitLabAccessTokenHeaderName,
    string GitLabAccessToken);
