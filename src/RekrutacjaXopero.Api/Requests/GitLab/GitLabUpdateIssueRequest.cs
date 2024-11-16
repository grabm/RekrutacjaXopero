namespace RekrutacjaXopero.Api.Requests.GitLab;

public record GitLabUpdateIssueRequest(
    string ProjectId,
    int IssueId,
    string Title = null,
    string Description = null,
    string StateEvent = null);
