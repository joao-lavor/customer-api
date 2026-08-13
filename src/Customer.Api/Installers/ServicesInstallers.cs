using Customer.Application.Interfaces;
using Customer.Application.Services;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Services;

namespace Customer.Api.Installers
{
    public static class ServicesInstallers
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAppCustomerService, AppCustomerService>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
