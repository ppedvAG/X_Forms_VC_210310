using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using XamarinFormsTest.Uebungen.BankingApp_MVVM.Model;

namespace XamarinFormsTest.Uebungen.BankingApp_MVVM.Service
{
    public class DatabaseService
    {
        private SQLiteConnection con;
        private readonly string pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "banking.sqlite");

        public DatabaseService()
        {
            con = new SQLiteConnection(pfad);
            CreateTables();
        }

        private void CreateTables()
        {
            con.CreateTable<Person>();
            con.CreateTable<Account>();
        }

        public void Insert(object obj)
        {
            if (obj is Account || obj is Person)
                con.Insert(obj);
        }

        public T Get<T>(int id) where T : new()
        {
            return con.Get<T>(id);
        }

        public ObservableCollection<T> GetAll<T>() where T : new()
        {
            return new ObservableCollection<T>(con.Table<T>().ToList());
        }

        public void Delete(object obj)
        {
            if (obj is Account || obj is Person)
                con.Delete(obj);
        }

        public void Update(object obj)
        {
            if (obj is Account || obj is Person)
                con.Update(obj);
        }
    }
}

