using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace X_Forms
{
    //Das Interface INotifyPropertyChanged informiert die GUI über Veränderungen in angebundenen .NET-Properties.
    //Dazu muss das PropertyChanged-Event gefeuert werden, wenn die GUI auf eine Veränderung informieren soll (normalerweise innerhalb des Setters)
    public class Person : INotifyPropertyChanged
    {
        public string Vorname { get; set; }

        private string nachname;
        public string Nachname 
        { 
            get => nachname; 
            set
            {
                nachname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nachname)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
