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

namespace X_Forms.PersonenDb.Nav
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
                     new MDPMasterMenuItem { Id = 0, Title = "Add new person", TargetType=typeof(Pages.Pg_Add) },
                     new MDPMasterMenuItem { Id = 1, Title = "List" , TargetType=typeof(Pages.Pg_List)}
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