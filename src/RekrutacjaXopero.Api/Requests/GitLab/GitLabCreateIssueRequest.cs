namespace RekrutacjaXopero.Api.Requests.GitLab;

public record GitLabCreateIssueRequest(
    string ProjectId,
    string Title,
    string Description);
