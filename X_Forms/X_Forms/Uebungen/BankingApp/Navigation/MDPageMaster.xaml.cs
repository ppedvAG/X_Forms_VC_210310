using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsTest.Uebungen.BankingApp_MVVM.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPageMaster : ContentPage
    {
        public ListView ListView;

        public MDPageMaster()
        {
            InitializeComponent();

            BindingContext = new MDPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MDPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPageMasterMenuItem> MenuItems { get; set; }

            public MDPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPageMasterMenuItem>(new[]
                {
                    new MDPageMasterMenuItem { Id = 0, Title = "Startseite", TargetType = typeof(View.BankingView) },
                    new MDPageMasterMenuItem { Id = 1, Title = "Konto anlegen", TargetType=typeof(View.AddAccountView)},
                    new MDPageMasterMenuItem { Id = 2, Title = "Einzahlen/Auszahlen", TargetType=typeof(View.DepositWithdrawView) },
                    new MDPageMasterMenuItem { Id = 4, Title = "Logout"},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}