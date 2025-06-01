using MauiMenuApi.BusinessLayer.Services;
using MauiMenuApi.BusinessLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MauiMenuApi.BusinessLayer.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddTransient<IMenuItemService, MenuItemService>();

            return services;
        }
    }
}
