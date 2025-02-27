using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace oceny.Models;

public class Uczen : INotifyPropertyChanged
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public ObservableCollection<int> Oceny { get; set; } = new ObservableCollection<int>();

    public double Srednia => Oceny.Any() ? Oceny.Average() : 0;

    public event PropertyChangedEventHandler PropertyChanged;

    public void DodajOcene(int ocena)
    {
        Oceny.Add(ocena);
        OnPropertyChanged(nameof(Srednia));
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
