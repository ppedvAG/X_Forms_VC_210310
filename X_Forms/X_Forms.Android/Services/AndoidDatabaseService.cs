using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X_Forms.Droid.Services;
using X_Forms.PersonenDb.Services;
using Xamarin.Forms;

//Mittels des Assambly-Attributs Dependency kann diese Klasse beim DependencyService angemeldet werden.
[assembly: Dependency(typeof(AndoidDatabaseService))]
namespace X_Forms.Droid.Services
{
    //Diese Klasse erbt von dem allgemeinen Interface IDatabaseService, damit der DependencyService die Zuweisung durchführen kann
    public class AndoidDatabaseService : IDatabaseService
    {
        //Methode zum Etablieren der Verbindung
        public SQLiteConnection GetConnection()
        {
            //Kreieren des Datenbankpfads
            string ordner = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbName = "PersonenDB.db3";

            string path = Path.Combine(ordner, dbName);

            //Instanziierung und Rückgabe des Connection-Objekts
            SQLiteConnection con = new SQLiteConnection(path);
            return con;
        }
    }
}