using Customer.Api.Installers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddServices()
        .AddRepositories(configuration)
        .AddSwagger();

services.AddControllers();
services.AddEndpointsApiExplorer();

var app = builder.Build();
app.SwaggerConfiguration();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
await app.RunAsync();