using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using XamarinFormsTest.Uebungen.BankingApp_MVVM.Model;

namespace XamarinFormsTest.Uebungen.BankingApp_MVVM.Service
{
    public static class AccountService
    {
        public static ObservableCollection<Account> AccountList { get; set; }

        internal static void LoadAccounts()
        {
            DatabaseService dbService = new DatabaseService();
            AccountList = dbService.GetAll<Account>();
        }
        internal static ObservableCollection<Account> GetAccounts(int ownerId)
        {
            try
            {
                LoadAccounts();
                return new ObservableCollection<Account>(AccountList.Where(x => x.OwnerId == ownerId));
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal static void Insert(Account account)
        {
            DatabaseService dbService = new DatabaseService();

            AccountList.Add(account);
            dbService.Insert(account);
        }

        public static void Deposit(Account account, double sum)
        {
            DatabaseService dbService = new DatabaseService();
            account.Balance += sum;
            dbService.Update(account);
        }

        public static void Withdraw(Account account, double sum)
        {
            DatabaseService dbService = new DatabaseService();
            account.Balance -= sum;
            dbService.Update(account);
        }
    }
}
