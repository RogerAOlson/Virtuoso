namespace MarketingWeb.ViewModelProviders
{
    public interface IContactSelectViewModelProvider
    {
        Task<IResult> ExecuteAsync(
            int contactId,
            ILogger logger);
    }
}
