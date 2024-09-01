using ContactManager.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManagerRepositoryDB
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterContactManagerRepository(this IServiceCollection services)
        {
            services.AddScoped<IContactManangerRepositoryContactSelect, Repository>();
            services.AddScoped<IContactManangerRepositoryContactAdd, Repository>();
            services.AddScoped<IContactManangerRepositoryContactDelete, Repository>();
            services.AddScoped<IContactManangerRepositoryContactUpdate, Repository>();
        }
    }
}
