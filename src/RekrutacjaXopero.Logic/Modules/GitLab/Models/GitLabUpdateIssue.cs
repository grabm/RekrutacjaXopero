namespace RekrutacjaXopero.Logic.Modules.GitLab.Models;

public record GitLabUpdateIssue(
    string ProjectId,
    int IssueId,
    string Title = null,
    string Description = null,
    string StateEvent = null);
