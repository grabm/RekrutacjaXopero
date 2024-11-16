using RekrutacjaXopero.Logic.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekrutacjaXopero.Logic.Modules.GitHub.Models;

public class GitHubIssueService : IssueService<GitHubCreateIssue, GitHubUpdateIssue, GitHubCloseIssue>
{
    public GitHubIssueService(
        IssueUris issueUris,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory, issueUris)
    {
    }

    protected override string GetCreateIssueUri(GitHubCreateIssue gitHubCreateIssue)
    {
        return $"{_issueUris.Create}/{gitHubCreateIssue.Owner}/{gitHubCreateIssue.Repo}/issues";
    }

    protected override string GetUpdateIssueUri(GitHubUpdateIssue gitHubUpdateIssue)
    {
        return $"{_issueUris.Update}/{gitHubUpdateIssue.Owner}/{gitHubUpdateIssue.Repo}/issues/{gitHubUpdateIssue.IssueNumber}";
    }

    protected override string GetCloseIssueUri(GitHubCloseIssue gitHubCloseIssue)
    {
        return $"{_issueUris.Close}/{gitHubCloseIssue.Owner}/{gitHubCloseIssue.Repo}/issues/{gitHubCloseIssue.IssueNumber}";
    }
}
