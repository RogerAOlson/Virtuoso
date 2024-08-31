using ContactManager.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Repository
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterContactManagerRepository(this IServiceCollection services)
        {
            services.AddScoped<IContactManangerRepositoryContactSelect, ContactManagerRepository.Repository>();
            services.AddScoped<IContactManangerRepositoryContactAdd, ContactManagerRepository.Repository>();
            services.AddScoped<IContactManangerRepositoryContactDelete, ContactManagerRepository.Repository>();
            services.AddScoped<IContactManangerRepositoryContactUpdate, ContactManagerRepository.Repository>();
        }
    }
}
