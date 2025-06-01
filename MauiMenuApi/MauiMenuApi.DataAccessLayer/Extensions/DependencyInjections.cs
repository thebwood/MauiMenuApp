using Microsoft.Extensions.DependencyInjection;
using MauiMenuApi.DataAccessLayer.Repositories;
using MauiMenuApi.DataAccessLayer.Repositories.Interfaces;

namespace MauiMenuApi.DataAccessLayer.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services, string? connectionString)
        {
            services.AddTransient<IMenuItemRepository, MenuItemRepository>(sp =>
            {
                return new MenuItemRepository(connectionString);
            });

            return services;
        }
    }
}
