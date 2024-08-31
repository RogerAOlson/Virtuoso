using MarketingWeb.ViewModels;

namespace MarketingWeb.ViewModelProviders
{
    public interface IContactUpdateViewModelProvider
    {
        Task<IResult> ExecuteAsync(
            ContactUpdateViewModel UpdateContactViewModel,
            ILogger logger);
    }
}
