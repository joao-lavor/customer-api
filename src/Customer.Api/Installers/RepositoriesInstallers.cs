using Customer.InfraStructure.Installers;
using Customer.InfraStructure.Interfaces;

namespace Customer.Api.Installers
{
    public static class RepositoriesInstallers
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConnection<IMySqlDbConnection>(configuration, "connectionStr");
            return services;
        }
    }
}
