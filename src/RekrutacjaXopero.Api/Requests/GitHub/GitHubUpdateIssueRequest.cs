namespace RekrutacjaXopero.Api.Requests.GitHub;

public record GitHubUpdateIssueRequest(
    string Owner,
    string Repo,
    int IssueNumber,
    string Title = null,
    string Description = null,
    string State = null);
