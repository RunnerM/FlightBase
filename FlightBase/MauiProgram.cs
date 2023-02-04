using FlightBase.Shared.Services;
using FlightBase.Shared.Services.Android;
using FlightBase.Shared.Services.Windows;
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
        //device specific services
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            mauiAppBuilder.Services.AddSingleton<ISerialService,AndroidSerialService>();
        }
        else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
        {
            mauiAppBuilder.Services.AddSingleton<ISerialService,WindowsSerialService>();
        }
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