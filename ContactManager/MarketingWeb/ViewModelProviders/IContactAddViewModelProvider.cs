using MarketingWeb.ViewModels;

namespace MarketingWeb.ViewModelProviders
{
    public interface IContactAddViewModelProvider
    {
        Task<IResult> ExecuteAsync(
            ContactAddViewModel ContactAddViewModel,
            ILogger logger);
    }
}
