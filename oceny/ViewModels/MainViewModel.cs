using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using oceny.Models;

namespace oceny.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Uczen> Uczniowie { get; set; } = new ObservableCollection<Uczen>();
        public ICommand WyswietlUczniaCommand { get; }
        public ICommand DodajOceneCommand { get; }
        public ICommand ObliczSredniaCommand { get; }
        public MainViewModel()
        {
            Uczniowie.Add(new Uczen { Imie = "Jan", Nazwisko = "Kowalski" });
            Uczniowie.Add(new Uczen { Imie = "Anna", Nazwisko = "Nowak" });
            Uczniowie.Add(new Uczen { Imie = "Michał", Nazwisko = "Wójcik" });
            Uczniowie.Add(new Uczen { Imie = "Katarzyna", Nazwisko = "Zielona" });
            Uczniowie.Add(new Uczen { Imie = "Paweł", Nazwisko = "Nowicki" });

            WyswietlUczniaCommand = new Command<Uczen>(WyswietlUcznia);
            DodajOceneCommand = new Command<Uczen>(DodajOcene);
            ObliczSredniaCommand = new Command<Uczen>(ObliczSrednia);
        }
        private async void WyswietlUcznia(Uczen uczen)
        {
            string ocenyStr = string.Join("\n", uczen.Oceny.Select(o =>
                $"{o.Przedmiot}: {o.Wartosc} (Data: {o.Data:dd.MM.yyyy})"));

            await Application.Current.MainPage.DisplayAlert(
                $"Uczeń: {uczen.Imie} {uczen.Nazwisko}",
                $"Średnia: {uczen.Srednia:F1}\nOceny:\n{ocenyStr}",
                "OK");
        }
        private async void DodajOcene(Uczen uczen)
        {
            string ocenaStr = await Application.Current.MainPage.DisplayPromptAsync(
                "Dodaj ocenę", "Wpisz ocenę (1-6):", "OK", "Anuluj", keyboard: Keyboard.Numeric);

            if (int.TryParse(ocenaStr, out int ocena) && ocena >= 1 && ocena <= 6)
            {
                string przedmiot = await Application.Current.MainPage.DisplayPromptAsync(
                    "Przedmiot", "Wpisz nazwę przedmiotu:");

                uczen.DodajOcene(ocena, przedmiot);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Błąd", "Podano niepoprawną ocenę", "OK");
            }
        }
        private async void ObliczSrednia(Uczen uczen)
        {
            double srednia = uczen.Srednia;
            await Application.Current.MainPage.DisplayAlert(
                $"Średnia dla {uczen.Imie} {uczen.Nazwisko}",
                $"Średnia: {srednia:F1}",
                "OK");
        }
    }
}
