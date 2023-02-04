using Android.App;
using Android.Content;
using Android.Hardware.Usb;
using Android.Content.PM;
using Hoho.Android.UsbSerial.Driver;

[assembly: UsesFeature("android.hardware.usb.host")]

namespace FlightBase;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new[] { UsbManager.ActionUsbDeviceAttached })]
[MetaData(UsbManager.ActionUsbDeviceAttached, Resource = "@xml/device_filter")]
public class MainActivity : MauiAppCompatActivity
{
    static readonly string TAG = typeof(MainActivity).Name;
    const string ACTION_USB_PERMISSION = "com.hoho.android.usbserial.examples.USB_PERMISSION";

    UsbManager usbManager;
    BroadcastReceiver detachedReceiver;
    UsbSerialPort selectedPort;
    
}