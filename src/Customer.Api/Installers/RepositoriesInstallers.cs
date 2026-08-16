using Customer.Domain.Interfaces.Repositories;
using Customer.InfraStructure.Installers;
using Customer.InfraStructure.Interfaces;
using Customer.InfraStructure.Repositories;

namespace Customer.Api.Installers
{
    public static class RepositoriesInstallers
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConnection<IMySqlDbConnection>(configuration, "connectionStr");
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
