using FlightBase.Shared.Services;
using FlightBase.Shared.ViewModel;
using Microsoft.Extensions.Logging;

namespace FlightBase;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .RegisterAppServices()
            .RegisterViewModels();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        //general services
        mauiAppBuilder.Services.AddSingleton<ISerialService, SerialService>();
        // map services
        mauiAppBuilder.UseMauiMaps();
        return mauiAppBuilder;
    }
    
    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<SettingsViewModel>();
        mauiAppBuilder.Services.AddSingleton<MapViewModel>();
        mauiAppBuilder.Services.AddSingleton<MainViewModel>();
        return mauiAppBuilder;
    }
}