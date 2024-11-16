namespace RekrutacjaXopero.Api.Requests.GitHub;

public record GitHubCreateIssueRequest(
    string Owner,
    string Repo,
    string Title);
