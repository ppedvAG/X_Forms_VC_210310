using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X_Forms.PersonenDb.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pg_List : ContentPage
    {
        public Pg_List()
        {
            //GUI-Initialisierung
            InitializeComponent();

            StaticObjects.PersonenListe = new ObservableCollection<Model.Person>(StaticObjects.PersonDatenbank.GetPeople());

            //Setzen des BindingContexts
            this.BindingContext = this;
        }

        //List-Property (zur Bindung), welche auf die StaticObjects-Liste zeigt
        public ObservableCollection<Model.Person> PersonenListe { get => StaticObjects.PersonenListe; set => StaticObjects.PersonenListe = value; }

        //EventHandler zum Löschen einer Person
        private async void CaMenu_Delete_Clicked(object sender, EventArgs e)
        {
            //Cast des Inhalts der CommandParameter-Property des Sender-Objekts (das ausgewählte ListView-Item) in Person-Objekt
            Model.Person p = (sender as MenuItem).CommandParameter as Model.Person;

            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschen", $"Soll {p.Vorname} {p.Nachname} wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen aus lokaler Liste
                StaticObjects.PersonenListe.Remove(p);
                //Löschen aus Datenbank
                StaticObjects.PersonDatenbank.DeletePerson(p);

                //Ausgabe eines Toasts
                ToastController.ShowToastMessage($"{p.Vorname} {p.Nachname} wurde gelöscht.", ToastDuration.Long);
            }

        }
    }
}