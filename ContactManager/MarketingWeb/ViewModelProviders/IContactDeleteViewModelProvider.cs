namespace MarketingWeb.ViewModelProviders
{
    public interface IContactDeleteViewModelProvider
    {
        Task<IResult> ExecuteAsync(
            int contactId,
            ILogger logger);
    }
}
