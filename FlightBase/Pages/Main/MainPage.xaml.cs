﻿using System.Reflection.Metadata;
using FlightBase.Shared.Services.Common;
using FlightBase.Shared.ViewModel;

namespace FlightBase;

public partial class MainPage : ContentPage
{
    
    public MainPage(MainViewModel mainViewModel)
    {
        InitializeComponent();
        AltitudeLabel.Text = "0";
        LocationLabel.Text = "0";
        SpeedLabel.Text = "0";
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            LogRowDefinition.Height = new GridLength(350);
        else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
            LogRowDefinition.Height = new GridLength(500);
        BindingContext = mainViewModel;
        
    }

    private void ClearLogButtonPressed(object sender, EventArgs e)
    {
        ((MainViewModel) BindingContext).ClearLog();
    }
}