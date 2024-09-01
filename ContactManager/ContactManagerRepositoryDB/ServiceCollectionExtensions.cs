using ContactManager.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManagerRepositoryDB
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterContactManagerRepository(this IServiceCollection services)
        {
            services.AddScoped<IContactManagerRepositoryContactSelect, Repository>();
            services.AddScoped<IContactManagerRepositoryContactAdd, Repository>();
            services.AddScoped<IContactManagerRepositoryContactDelete, Repository>();
            services.AddScoped<IContactManagerRepositoryContactUpdate, Repository>();
        }
    }
}
