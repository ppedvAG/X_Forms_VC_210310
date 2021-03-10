using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class MainPage : ContentPage
    {
        //Property zum Zwischenspeichern der Personenliste (ObservableCollection ist eine generische Liste, welche die GUI
        //automatisch über Veränderungen innerhalb der Liste informiert)
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Anna", Nachname="Nass"}
        };

        //Konstruktor
        public MainPage()
        {
            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Neuzuweisung einer UI-Property über die x:Name-Property des Steuerelements
            Lbl_Main.Text = "Neuer String";

            //Zuweisung von EventHandlern zu den Completed-Events, damit ein besserer Bedienfluss gegeben ist
            Ent_Vorname.Completed += (s, e) => Ent_Nachname.Focus();
            Ent_Nachname.Completed += ImageButton_Clicked;

            //Durch Setzen des BindingContextes nehmen Kurzbindungen aus dem XAML-Code automatisch Bezug auf die Properties
            //des im BindingContext gesetzten Objekts
            this.BindingContext = this;
        }

        //EventHandler
        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            //Neuzuweisung der Textproperty des Labeld mit dem Ausgewählten Element des Pickers
            Lbl_Main.Text = Pkr_Monkeys.SelectedItem.ToString();

            //Neuzuweisung einer Property des Eventauslösenden Steuerelements
            (sender as Button).Text = "Geklicketer Button";
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool erg = await DisplayAlert("Begrüßung", $"Sei gegrüßt {Ent_Vorname.Text} {Ent_Nachname.Text}!\nSoll ein Eintrag erstellt werden?", "Ja", "Nein");

            if (erg)
                //Hinzufügen eines neuen Elements zur Liste (ObservableCollection informiert das ListView über Veränderung)
                Personenliste.Add(new Person() { Vorname = Ent_Vorname.Text, Nachname = Ent_Nachname.Text });
            else
                await DisplayAlert("NEIN", "Schade auch", "Ok");
        }

        private void Btn_NameAendern_Clicked(object sender, EventArgs e)
        {
            //Änderung einer Property des BindingContexts des StackLayouts (INotifyPropertyChanged informiert GUI über Veränderung (vgl. Person.cs))
            (Stl_DataBinding.BindingContext as Person).Nachname = "Müller";
        }
    }
}
