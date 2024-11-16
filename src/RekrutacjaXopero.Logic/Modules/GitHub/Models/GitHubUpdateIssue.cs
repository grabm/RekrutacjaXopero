namespace RekrutacjaXopero.Logic.Modules.GitHub.Models;

public record GitHubUpdateIssue(
    string Owner,
    string Repo,
    int IssueNumber,
    string Title = null,
    string Description = null,
    string State = null);
