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

namespace X_Forms.NavigationBsps.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPMaster : ContentPage
    {
        public ListView ListView;

        public MDPMaster()
        {
            InitializeComponent();

            BindingContext = new MDPMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MDPMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPMasterMenuItem> MenuItems { get; set; }

            public MDPMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPMasterMenuItem>(new[]
                {
                    new MDPMasterMenuItem { Id = 0, Title = "MainPage", TargetType=typeof(MainPage) },
                    new MDPMasterMenuItem { Id = 1, Title = "AbsoluteLayout", TargetType=typeof(Layouts.AbsoluteLayoutBsp) },
                    new MDPMasterMenuItem { Id = 2, Title = "TabbedPage", TargetType=typeof(NavigationBsps.TabbedPageBsp) },
                    new MDPMasterMenuItem { Id = 3, Title = "PersonenDB", TargetType=typeof(PersonenDb.Nav.MDP) },
                    new MDPMasterMenuItem { Id = 4, Title = "MVVMBsp", TargetType=typeof(MVVMBsp.View.MainView) },
                    new MDPMasterMenuItem { Id = 5, Title = "GoogleBooks", TargetType=typeof(Uebungen.GoogleBooks.View.MainView) },
                    new MDPMasterMenuItem { Id = 6, Title = "BankingApp", TargetType=typeof(XamarinFormsTest.Uebungen.BankingApp_MVVM.View.LoginView) },
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