using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace oceny.Models
{
    public class Uczen : INotifyPropertyChanged
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public ObservableCollection<Ocena> Oceny { get; set; } = new ObservableCollection<Ocena>();
        public double Srednia => Oceny.Any() ? Oceny.Average(o => o.Wartosc) : 0;
        public event PropertyChangedEventHandler PropertyChanged;
        public void DodajOcene(int wartosc, string przedmiot)
        {
            Oceny.Add(new Ocena { Wartosc = wartosc, Przedmiot = przedmiot, Data = DateTime.Now });
            OnPropertyChanged(nameof(Srednia));
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Ocena
    {
        public int Wartosc { get; set; }
        public string Przedmiot { get; set; }
        public DateTime Data { get; set; }
    }
}
