using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.PersonenDb.Services
{
    //Der PersonenDbController handelt alle Person-betreffenden Datenbankanfragen mithilfe des DependencyServices.
    //Der globale Zugriff auf den Controller erfolgt in diesem Beispiel über die StaticObjects-Klasse.
    public class PersonenDbController
    {
        //Connection-Objekt
        SQLiteConnection database;

        //Statische Locker-Objekte werden benutzt um einen gleichzeitigen Datenbankzugriff durch dieselbe App zu verhindern
        static object locker = new object();

        //Konstruktor
        public PersonenDbController()
        {
            //Mittels des lock-Stichworts kann der Datenbankzugriff mittels eines spezifischen Objekts limitiert werden
            lock (locker)
            {
                //Erstellen des Connection-Objekts mittels der OS-spezifischen Klassen. Der DependencyService sucht automatisch
                //die dem aktuellen OS entsprechende Klasse (wenn vohanden)
                IDatabaseService dbService = DependencyService.Get<IDatabaseService>();

                //Erstellung des Connection-Objekts
                database = dbService.GetConnection();

                //Erstellen einer neuen Person-Tabelle (wenn noch nicht vorhanden)
                database.CreateTable<Model.Person>();
            }
        }

        //Methoden für die verschiedenen Datenbankzugriffsarten
        public Person GetPerson(Guid id)
        {
            lock (locker)
            {
                //Erfragen eines einzelnen Person-Objekts anhand der Id
                return database.Get<Person>(id);
            }
        }

        public List<Model.Person> GetPeople()
        {
            lock (locker)
            {
                //Erfragen aller Person-Objekte der Datenbank
                return database.Table<Model.Person>().ToList();
            }
        }

        public void AddPerson(Model.Person person)
        {
            lock (locker)
            {
                //Hinzufügen einer Person zur Datenbank
                database.Insert(person);
            }
        }

        public void DeletePerson(Model.Person person)
        {
            lock (locker)
            {
                //Löschen einer Person in der Datenbank
                database.Delete(person);
            }
        }

    }
}
