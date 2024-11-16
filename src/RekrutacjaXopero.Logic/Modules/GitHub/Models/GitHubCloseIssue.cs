namespace RekrutacjaXopero.Logic.Modules.GitHub.Models;

public record GitHubCloseIssue(
    string Owner,
    string Repo,
    int IssueNumber);
