using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsTest.Uebungen.BankingApp_MVVM.Model
{
    public enum AccType
    {
        Giro,
        Save
    }

    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        public AccType AccountType { get; set; }
        public int OwnerId { get; set; }

        [Ignore]
        public Person Owner { get; set; }

        public override string ToString()
        {
            return $"({AccountNumber}) - {AccountType} - {Balance}€";
        }
    }
}
