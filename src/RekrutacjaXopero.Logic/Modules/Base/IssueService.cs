using System.Net.Http.Json;

namespace RekrutacjaXopero.Logic.Modules.Base;

public abstract class IssueService<TCreateIssueModel, TUpdateIssueModel, TCloseIssueModel>
: IIssueService<TCreateIssueModel, TUpdateIssueModel, TCloseIssueModel>
{
    protected readonly IHttpClientFactory _httpClientFactory;
    protected readonly IssueUris _issueUris;

    public IssueService(
        IHttpClientFactory httpClientFactory,
        IssueUris issueUris)
    {
        _httpClientFactory = httpClientFactory;
        _issueUris = issueUris;
    }

    protected abstract string GetCreateIssueUri(TCreateIssueModel createIssueModel);
    protected abstract string GetUpdateIssueUri(TUpdateIssueModel updateIssueModel);
    protected abstract string GetCloseIssueUri(TCloseIssueModel closeIssueModel);

    public virtual async Task CreateAsync(
        TCreateIssueModel createIssueModel,
        CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient();

        string createIssueUri = GetCreateIssueUri(createIssueModel);

        await httpClient.PostAsJsonAsync(_issueUris.Create, createIssueUri, cancellationToken);
    }

    public virtual async Task UpdateAsync(
        TUpdateIssueModel updateIssueModel,
        CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient();

        string updateIssueUri = GetUpdateIssueUri(updateIssueModel);

        await httpClient.PatchAsJsonAsync(_issueUris.Update, updateIssueUri, cancellationToken);
    }

    public virtual async Task CloseAsync(TCloseIssueModel closeIssueModel, CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient();

        string updateIssueUri = GetCloseIssueUri(closeIssueModel);

        var response = await httpClient.PatchAsJsonAsync(_issueUris.Close, closeIssueModel, cancellationToken);
    }
}
