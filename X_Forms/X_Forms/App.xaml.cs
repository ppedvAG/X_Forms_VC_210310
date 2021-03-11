using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            //MainPage = new NavigationPage(new MainPage());

            MainPage = new NavigationBsps.MasterDetail.MDP();
        }

        public DateTime TimeStamp { get; set; }

        //Methoden, welche zu bestimmten globalen Events ausgeführt werden (Start, Unterbrechen der App [Sleep], Wiederaktivierung der App [Resume])
        protected override void OnStart()
        {
            MainPage.DisplayAlert("Time", $"{DateTime.Now.ToLongTimeString()}", "ok");
        }

        protected override void OnSleep()
        {
            TimeStamp = DateTime.Now;
        }

        protected override void OnResume()
        {
            MainPage.DisplayAlert("Time", $"Geschlafene Zeit: {DateTime.Now.Subtract(TimeStamp).TotalSeconds}", "ok");
        }
    }
}
