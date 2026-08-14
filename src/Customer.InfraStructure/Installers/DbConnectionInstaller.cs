using Customer.InfraStructure.Interfaces;
using Customer.InfraStructure.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.InfraStructure.Installers
{
    public static class DbConnectionInstaller
    {
        public static IServiceCollection AddConnection<TdbConnection>(this IServiceCollection services, IConfiguration configuration, string ConnectionStr)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStr);
            var mySqlConnection = new MySqlDbConnection(connectionString);
            services.AddScoped<IMySqlDbConnection>(provider => mySqlConnection);
            return services;
        }
    }
}
