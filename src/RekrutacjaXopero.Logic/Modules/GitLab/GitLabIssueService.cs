using RekrutacjaXopero.Logic.Modules.Base;
using RekrutacjaXopero.Logic.Modules.GitLab.Models;

namespace RekrutacjaXopero.Logic.Modules.GitLab;

public class GitLabIssueService : IssueService<GitLabCreateIssue, GitLabUpdateIssue, GitLabCloseIssue>
{
    public GitLabIssueService(
        IssueUris issueUris,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory, issueUris)
    {
    }

    protected override string GetCreateIssueUri(GitLabCreateIssue gitLabCreateIssue)
    {
        return $"{_issueUris.Create}/projects/{gitLabCreateIssue.ProjectId}/issues";
    }

    protected override string GetUpdateIssueUri(GitLabUpdateIssue gitLabUpdateIssue)
    {
        return $"{_issueUris.Update}/projects/{gitLabUpdateIssue.ProjectId}/issues/{gitLabUpdateIssue.IssueId}";
    }

    protected override string GetCloseIssueUri(GitLabCloseIssue gitLabCloseIssue)
    {
        return $"{_issueUris.Close}/projects/{gitLabCloseIssue.ProjectId}/issues/{gitLabCloseIssue.IssueId}";
    }
}
