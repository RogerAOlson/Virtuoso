using ContactManager.Repository.ContactManager;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManagerRepository
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterContactManagerRepository(this IServiceCollection services)
        {
            services.AddScoped<IContactManangerRepositoryContactSelect, Repository.ContactManager.Repository>();
            services.AddScoped<IContactManangerRepositoryContactAdd, Repository.ContactManager.Repository>();
            services.AddScoped<IContactManangerRepositoryContactDelete, Repository.ContactManager.Repository>();
            services.AddScoped<IContactManangerRepositoryContactUpdate, Repository.ContactManager.Repository>();
        }
    }
}
