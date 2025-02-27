using Microsoft.Maui.Controls;

namespace oceny;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new Views.MainPage());
    }
}
