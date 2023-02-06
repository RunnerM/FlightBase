using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBase.Shared.Services;
using FlightBase.Shared.Services.Common;
using FlightBase.Shared.ViewModel;

namespace FlightBase;

public partial class SettingsPage : ContentPage
{
    private bool _isConnected => ((SettingsViewModel) BindingContext).IsConnected;

    public SettingsPage()
    {
        if (Handler?.MauiContext != null)
            BindingContext = new SettingsViewModel(Handler.MauiContext.Services.GetService<ISerialService>());
        InitializeComponent();
    }

    protected override void OnHandlerChanged()
    {
        if (Handler?.MauiContext != null)
            BindingContext = new SettingsViewModel(Handler.MauiContext.Services.GetService<ISerialService>());
    }

    private void BaudPickerOnSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker) sender;
        var rate = (int) picker.SelectedItem;
        ((SettingsViewModel) BindingContext).SetBaudRate(rate);
    }

    private void PortPickerOnSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker) sender;
        var port = (string) picker.SelectedItem;
        ((SettingsViewModel) BindingContext).ConfigurePort(port);
    }

    private void ReScanPortsButtonOnPressed(object sender, EventArgs e)
    {
        ((SettingsViewModel) BindingContext).ScanPorts();
    }

    private void ConnectButtonOnPressed(object sender, EventArgs e)
    {
        if (!_isConnected)
            ((SettingsViewModel) BindingContext).Connect();
        else
            ((SettingsViewModel) BindingContext).Disconnect();
    }
}