using Microsoft.AspNetCore.Mvc;
using RekrutacjaXopero.Api.Requests.GitLab;
using RekrutacjaXopero.Logic.Modules.GitLab;
using RekrutacjaXopero.Logic.Modules.GitLab.Models;

namespace RekrutacjaXopero.Api.Controllers;

[ApiController]
[Route("api/issues/[controller]")]
public class GitLabController : Controller
{
    private readonly GitLabIssueService _gitLabIssueService;

    public GitLabController(GitLabIssueService gitLabIssueService)
    {
        _gitLabIssueService = gitLabIssueService;
    }

    public async Task CreateIssue(
        GitLabCreateIssueRequest gitLabCreateIssueRequest,
        CancellationToken cancellationToken)
    {
        var gitLabCreateIssue = new GitLabCreateIssue(
            gitLabCreateIssueRequest.ProjectId,
            gitLabCreateIssueRequest.Title,
            gitLabCreateIssueRequest.Description);

        await _gitLabIssueService.CreateAsync(gitLabCreateIssue, cancellationToken);
    }

    [HttpPut]
    public async Task UpdateIssue(
        GitLabUpdateIssueRequest gitLabUpdateIssueRequest,
        CancellationToken cancellationToken)
    {
        var gitLabUpdateIssue = new GitLabUpdateIssue(
            gitLabUpdateIssueRequest.ProjectId,
            gitLabUpdateIssueRequest.IssueId,
            gitLabUpdateIssueRequest.Title,
            gitLabUpdateIssueRequest.Description,
            gitLabUpdateIssueRequest.StateEvent);

        await _gitLabIssueService.UpdateAsync(gitLabUpdateIssue, cancellationToken);
    }

    [HttpDelete]
    public async Task CloseIssue(
        GitLabCloseIssueRequest gitLabCloseIssueRequest,
        CancellationToken cancellationToken)
    {
        var gitLabUpdateIssue = new GitLabCloseIssue(
            gitLabCloseIssueRequest.ProjectId,
            gitLabCloseIssueRequest.IssueId);

        await _gitLabIssueService.CloseAsync(gitLabUpdateIssue, cancellationToken);
    }
}
