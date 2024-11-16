namespace RekrutacjaXopero.Api.Requests.GitHub;

public record GitHubCloseIssueRequest(
    string Owner,
    string Repo,
    int IssueNumber);
