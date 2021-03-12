using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace X_Forms.MVVMBsp.Model
{
    //Der Model-Teil beinhaltet alle Modelklassen und evtl. Klassen, welche nur mit diesen interagieren.
    //Keine Model-Klasse darf einen Referenz auf den ViewModel- oder den Model-Teil beinhalten
    public class Person
    {
        public string Name { get; set; }
        public int Alter { get; set; }

        public static ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();
    }
}
