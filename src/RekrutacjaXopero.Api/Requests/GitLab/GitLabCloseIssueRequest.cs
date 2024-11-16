namespace RekrutacjaXopero.Api.Requests.GitLab;

public record GitLabCloseIssueRequest(
    string ProjectId,
    int IssueId);
