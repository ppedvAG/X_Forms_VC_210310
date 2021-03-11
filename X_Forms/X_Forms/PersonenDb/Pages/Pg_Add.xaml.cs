using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X_Forms.PersonenDb.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pg_Add : ContentPage
    {
        //Konstruktor
        public Pg_Add()
        {
            //GUI-Initialisierung
            InitializeComponent();

            //Completed-EventHandler-Zuweisung (User-Kompfort)
            Entry_Vorname.Completed += (s, e) => Entry_Nachname.Focus();
            Entry_Nachname.Completed += Btn_AddPerson_Clicked;
            Entry_Nachname.Completed += (s, e) => Entry_Vorname.Focus();
        }

        //Methode zum Hinzufügen einer neuen Person
        private void Btn_AddPerson_Clicked(object sender, EventArgs e)
        {
            //Objektinstanziierung mit User-Eingaben
            Model.Person person = new Model.Person()
            {
                Nachname = Entry_Nachname.Text,
                Vorname = Entry_Vorname.Text
            };

            //Hinzufügen zur lokalen Liste
            StaticObjects.PersonenListe.Add(person);
            //Hinzufügen zur Datenbank
            StaticObjects.PersonDatenbank.AddPerson(person);

            //Ausgabe eines Toasts
            ToastController.ShowToastMessage($"{person.Vorname} {person.Nachname} wurde hinzugefügt.", ToastDuration.Long);

            //Leeren  der Eingabefelder
            Entry_Vorname.Text = string.Empty;
            Entry_Nachname.Text = string.Empty;
        }
    }
}