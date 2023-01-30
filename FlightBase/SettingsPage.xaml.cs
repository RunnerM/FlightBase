using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBase;

public partial class SettingsPage : ContentPage
{
    public List<string> items { get; set; }
    

    public SettingsPage()
    {
        items = new List<string>
        {
            "Item 1",
            "Item 2",
            "Item 3",
        };
        InitializeComponent();
        Picker.ItemsSource = items;
    }
}