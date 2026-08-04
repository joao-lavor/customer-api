using Microsoft.OpenApi;

namespace Customer.Api.Installers
{
    public static class SwaggersInstallers
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Customer.Api", Version = "v1" });
            });
            return services;
        }

        public static IApplicationBuilder SwaggerConfiguration(this IApplicationBuilder app)
        {   
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer.Api v1");
                c.RoutePrefix = string.Empty;
            });
            return app;
        }
    }
}
