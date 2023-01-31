using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBase.Shared.Services;
using FlightBase.Shared.ViewModel;

namespace FlightBase;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        if(Handler?.MauiContext!=null)
            BindingContext = new SettingsViewModel(Handler.MauiContext.Services.GetService<ISerialService>());
        InitializeComponent();
    }

    protected override void OnHandlerChanged()
    {
        if (Handler?.MauiContext != null)
            BindingContext = new SettingsViewModel(Handler.MauiContext.Services.GetService<ISerialService>());
    }
}