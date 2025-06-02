using CommunityToolkit.Maui;
using MauiMenuApp.Mobile.Pages.Controls;
using MauiMenuApp.Mobile.ViewModels;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Toolkit.Hosting;
using Polly;
using Polly.Extensions.Http;
using MauiMenuApp.Mobile.Services.Interfaces;

namespace MauiMenuApp.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionToolkit()
                .ConfigureMauiHandlers(handlers =>
                {
#if IOS || MACCATALYST
    				handlers.AddHandler<Microsoft.Maui.Controls.CollectionView, Microsoft.Maui.Controls.Handlers.Items2.CollectionViewHandler2>();
#endif
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SegoeUI-Semibold.ttf", "SegoeSemibold");
                    fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
                });

#if DEBUG
    		builder.Logging.AddDebug();
    		builder.Services.AddLogging(configure => configure.AddDebug());
#endif
            // Set base address using platform-specific logic
            string baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                 ? "https://10.0.2.2:7009/" // Android emulator
                 : "https://localhost:7009/"; // iOS simulator
                                            // Define the retry policy
                                            // Define the retry policy
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError() // Handles 5xx and 408 errors
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

            // Add HttpClient with retry policy
            builder.Services.AddHttpClient<IMenuItemClient, MenuItemClient>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            })
                .AddPolicyHandler(retryPolicy); // Attach the retry policy

            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<SubMenuPageViewModel>();
            builder.Services.AddSingleton<SubMenuPage>();

            return builder.Build();
        }
    }
}
