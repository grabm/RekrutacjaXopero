namespace RekrutacjaXopero.Logic.Modules.GitHub.Models;

public record GitHubCreateIssue(
    string Owner,
    string Repo,
    string Title);
