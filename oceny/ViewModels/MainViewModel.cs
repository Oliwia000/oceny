using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using oceny.Models;

namespace oceny.ViewModels;

public class MainViewModel
{
    public ObservableCollection<Uczen> Uczniowie { get; set; } = new ObservableCollection<Uczen>();

    public ICommand WyswietlUczniaCommand { get; }
    public ICommand DodajOceneCommand { get; }

    public MainViewModel()
    {
        Uczniowie.Add(new Uczen { Imie = "Jan", Nazwisko = "Kowalski" });
        Uczniowie.Add(new Uczen { Imie = "Anna", Nazwisko = "Nowak" });

        WyswietlUczniaCommand = new Command<Uczen>(WyswietlUcznia);
        DodajOceneCommand = new Command<Uczen>(DodajOcene);
    }

    private async void WyswietlUcznia(Uczen uczen)
    {
        await Application.Current.MainPage.DisplayAlert(
            $"Uczeń: {uczen.Imie} {uczen.Nazwisko}",
            $"Średnia: {uczen.Srednia:F1}", "OK");
    }

    private async void DodajOcene(Uczen uczen)
    {
        string ocenaStr = await Application.Current.MainPage.DisplayPromptAsync(
            "Dodaj ocenę", "Wpisz ocenę (1-6):", "OK", "Anuluj", keyboard: Keyboard.Numeric);

        if (int.TryParse(ocenaStr, out int ocena) && ocena >= 1 && ocena <= 6)
        {
            uczen.DodajOcene(ocena);
        }
    }
}
