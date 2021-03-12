using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pg_Subscriber : ContentPage
    {
        public Pg_Subscriber()
        {
            InitializeComponent();

            //Abonieren der Nachricht unter Angabe von <Sender, Inhaltstyp>(Empfänger, Titel, Callback-Methode)
            MessagingCenter.Subscribe<MainPage, string>(this, "Nachricht", SetzeText);
        }

        //Methode, welche bei Empfang einer Nachricht ausgeführt wird
        private void SetzeText(MainPage sender, string text)
        {
            Lbl_Main.Text = text;
        }
    }
}