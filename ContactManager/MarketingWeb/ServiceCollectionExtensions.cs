using MarketingWeb.ViewModelProviders;

namespace MarketingWeb
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterMarketingWeb(this IServiceCollection services)
        {
            services.AddScoped<IContactSelectViewModelProvider, ContactSelectViewModelProvider>();
            services.AddScoped<IContactAddViewModelProvider, ContactAddViewModelProvider>();
            services.AddScoped<IContactUpdateViewModelProvider, ContactUpdateViewModelProvider>();
            services.AddScoped<IContactDeleteViewModelProvider, ContactDeleteViewModelProvider>();
        }
    }
}
