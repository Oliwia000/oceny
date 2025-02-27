using Microsoft.Maui.Controls;
using oceny.ViewModels;

namespace oceny.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();  
        BindingContext = new MainViewModel();
    }
}
