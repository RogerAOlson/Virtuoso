using ContactManager.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManagerRepositoryDict
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterContactManagerRepository(IServiceCollection services)
        {
            services.AddScoped<IContactManagerRepositoryContactSelect, Repository>();
            services.AddScoped<IContactManagerRepositoryContactAdd, Repository>();
            services.AddScoped<IContactManagerRepositoryContactDelete, Repository>();
            services.AddScoped<IContactManagerRepositoryContactUpdate, Repository>();
        }
    }
}
