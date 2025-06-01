using Serilog;

namespace MauiMenuApi.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configuration, ConfigureHostBuilder host)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            host.UseSerilog(( context, services, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(dispose: true);
            });
            return services;
        }
    }
}
