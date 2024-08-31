using ContactManager.Commands;
using ContactManager.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterContactManager(this IServiceCollection services)
        {
            services.AddScoped<IContactSelectService, ContactSelectService>();
            services.AddScoped<IContactAddService, ContactAddService>();
            services.AddScoped<IContactDeleteService, ContactDeleteService>();
            services.AddScoped<IContactUpdateService, ContactUpdateService>();
        }
    }
}