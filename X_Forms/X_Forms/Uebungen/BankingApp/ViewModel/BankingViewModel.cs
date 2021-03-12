using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsTest.Uebungen.BankingApp_MVVM.Model;
using XamarinFormsTest.Uebungen.BankingApp_MVVM.Service;
using XamarinFormsTest.Uebungen.BankingApp_MVVM.View;

namespace XamarinFormsTest.Uebungen.BankingApp_MVVM.ViewModel
{
    public class BankingViewModel : INotifyPropertyChanged
    {

        public BankingViewModel()
        {
            //BankingView
            AccountList = new ObservableCollection<Account>();
            AccountList = AccountService.GetAccounts(PersonService.SelectedPerson.Id);

            //AddAccountView
            AddGiroACmd = new Command(async () =>
            {
                if (await ShowAddAccMessage("Giro"))
                {
                    Random rand = new Random();

                    Account giro = new Account()
                    {
                        Balance = 0,
                        Owner = PersonService.SelectedPerson,
                        AccountNumber = rand.Next(1000, 9999),
                        AccountType = AccType.Giro,
                        OwnerId = PersonService.SelectedPerson.Id
                    };

                    AccountService.Insert(giro);
                }
            });

            AddSaveACmd = new Command(async () =>
            {
                if (await ShowAddAccMessage("Save"))
                {
                    Random rand = new Random();

                    Account spar = new Account()
                    {
                        Balance = 0,
                        Owner = PersonService.SelectedPerson,
                        AccountNumber = rand.Next(1000, 9999),
                        AccountType = AccType.Giro,
                        OwnerId = PersonService.SelectedPerson.Id
                    };

                    AccountService.Insert(spar);
                }
            });

            //DepositWithdrawView

            WithdrawMoneyCmd = new Command(() => AccountService.Withdraw(SelectedAccount, Amount));
            DepositMoneyCmd = new Command(() => AccountService.Deposit(SelectedAccount, Amount));
        }

        private async Task<bool> ShowAddAccMessage(string accType)
        {
            return await ContextPage.DisplayAlert("Create Account?", $"Add {accType} Account?", "Yes", "No");
        }

        public Page ContextPage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //BankingView
        private ObservableCollection<Account> accountList;
        public ObservableCollection<Account> AccountList
        {
            get { return accountList; }
            set
            {
                accountList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AccountList)));
            }
        }

        //AddAccountView
        public Command AddGiroACmd { get; set; }
        public Command AddSaveACmd { get; set; }

        //DepositWithdrawView
        public Account SelectedAccount { get; set; }
        public double Amount { get; set; }
        public Command WithdrawMoneyCmd { get; set; }
        public Command DepositMoneyCmd { get; set; }

    }
}
