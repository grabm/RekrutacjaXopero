namespace RekrutacjaXopero.Logic.Modules.Base
{
    public interface IIssueService<TCreateIssueModel, TUpdateIssueModel, TCloseIssueModel>
    {
        Task CreateAsync(TCreateIssueModel createIssueModel, CancellationToken cancellationToken = default);

        Task UpdateAsync(TUpdateIssueModel updateIssueModel, CancellationToken cancellationToken = default);

        Task CloseAsync(TCloseIssueModel closeIssueModel, CancellationToken cancellationToken = default);

    }
}
