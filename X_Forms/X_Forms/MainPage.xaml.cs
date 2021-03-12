using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            //Setzten der Ressourcensprache -> Bestimmt, welche resx-Bibliothek für die Lokalisierung verwendet wird
            Properties.Resources.Culture = new System.Globalization.CultureInfo("de");

            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Setzen eines Icons, welches in der Navigationsleiste (statt eines Titels) angezeigt wird
            NavigationPage.SetTitleIconImageSource(this, ImageSource.FromFile("test.png"));

            //Neuzuweisung einer UI-Property über die x:Name-Property des Steuerelements
            Lbl_Main.Text = "Neuer String";

            //Zuweisung von EventHandlern zu den Completed-Events, damit ein besserer Bedienfluss gegeben ist
            Ent_Vorname.Completed += (s, e) => Ent_Nachname.Focus();
            Ent_Nachname.Completed += ImageButton_Clicked;

            //Durch Setzen des BindingContextes nehmen Kurzbindungen aus dem XAML-Code automatisch Bezug auf die Properties
            //des im BindingContext gesetzten Objekts
            this.BindingContext = this;

            //Zugriff auf Xamarin.Essentials.Battery zur Anzeige des Batteriestandes (benötigt BatteryState-Permission)
            Lbl_Battery.Text = Battery.State.ToString() + " | Level: " + Battery.ChargeLevel * 100 + "%";
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

        private void Btn_NavigationPush_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage 
            Navigation.PushAsync(new Layouts.GridLayoutBsp());
        }

        private void Btn_NavigationPushModal_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage, welche aber keinen 'Zurück'-Button anzeigt
            Navigation.PushModalAsync(new Layouts.AbsoluteLayoutBsp());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Personenliste.Clear();
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschung", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen eines Listeneintrags
                Person person = (sender as MenuItem).CommandParameter as Person;

                Personenliste.Remove(person);
            }
        }

        private void Btn_Tabbed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationBsps.TabbedPageBsp());
        }

        //Bsp für Verwendung des MessagingCenters
        private void Btn_MC_Clicked(object sender, EventArgs e)
        {
            //Instanzieren des Empängerobjekts
            Page page = new Pg_Subscriber();

            //Senden der Nachricht mit Angabe des Senders, des Titels und des Inhalts
            MessagingCenter.Send(this, "Gesendeter Text", Pkr_Monkeys.SelectedItem.ToString());

            //Öffnen der Bsp-Seite
            Navigation.PushAsync(page);
        }

        private async void Btn_YouTube_Clicked(object sender, EventArgs e)
        {
            //Öffnen der Youtube-App über die Xamarin-Essentials mit Übergabe des Package-Namens
            if (await Launcher.CanOpenAsync("vnd.youtube://"))
                await Launcher.OpenAsync("vnd.youtube://rLKnqR9Oqh8");
        }
    }
}
