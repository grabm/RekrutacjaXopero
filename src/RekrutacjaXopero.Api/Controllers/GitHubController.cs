using Microsoft.AspNetCore.Mvc;
using RekrutacjaXopero.Api.Requests.GitHub;
using RekrutacjaXopero.Logic.Modules.GitHub.Models;

namespace RekrutacjaXopero.Api.Controllers;

[ApiController]
[Route("api/issues/[controller]")]
public class GitHubController : Controller
{
    private readonly GitHubIssueService _gitHubIssueService;

    public GitHubController(GitHubIssueService gitHubIssueService)
    {
        _gitHubIssueService = gitHubIssueService;
    }

    public async Task CreateIssue(
        GitHubCreateIssueRequest createGitHubIssue,
        CancellationToken cancellationToken)
    {
        var gitHubCreateIssue = new GitHubCreateIssue(
            createGitHubIssue.Owner,
            createGitHubIssue.Repo,
            createGitHubIssue.Title);

        await _gitHubIssueService.CreateAsync(gitHubCreateIssue, cancellationToken);
    }

    [HttpPut]
    public async Task UpdateIssue(
        GitHubUpdateIssueRequest updateGitHubIssue,
        CancellationToken cancellationToken)
    {
        var gitHubUpdateIssue = new GitHubUpdateIssue(
            updateGitHubIssue.Owner,
            updateGitHubIssue.Repo,
            updateGitHubIssue.IssueNumber,
            updateGitHubIssue.Title,
            updateGitHubIssue.Description,
            updateGitHubIssue.State);

        await _gitHubIssueService.UpdateAsync(gitHubUpdateIssue, cancellationToken);
    }

    [HttpDelete]
    public async Task CloseIssue(
        GitHubCloseIssueRequest gitHubCloseIssueRequest,
        CancellationToken cancellationToken)
    {
        var gitHubCloseIssue = new GitHubCloseIssue(
            gitHubCloseIssueRequest.Owner,
            gitHubCloseIssueRequest.Repo,
            gitHubCloseIssueRequest.IssueNumber);

        await _gitHubIssueService.CloseAsync(gitHubCloseIssue, cancellationToken);
    }
}
