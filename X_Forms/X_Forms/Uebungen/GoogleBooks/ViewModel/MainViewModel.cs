using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using X_Forms.Uebungen.GoogleBooks.Model;
using Xamarin.Forms;

//vgl. MVVMBsp/ViewModel
namespace X_Forms.Uebungen.GoogleBooks.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Interface-Event
        public event PropertyChangedEventHandler PropertyChanged;

        //Properties für DataBinding
        public string SearchString { get; set; }

        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing")); }
        }
        public Command SearchCommand { get; set; }
        public ObservableCollection<Item> BookList
        {
            get
            {
                return Model.Collections.BookList;
            }
            set
            {
                Model.Collections.BookList = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BookList)));
            }
        }

        //Command-Methode
        private async void SearchBooks()
        {
            if (!String.IsNullOrEmpty(SearchString))
                //Damit die View während des Suchprozesses nicht einfriert, muss diese Methode in einem seperaten Task laufen
                await Task.Run(() =>
                {
                    IsRefreshing = true;
                    GBook gBook = Service.BookService.FindBooks(SearchString);
                    BookList = new ObservableCollection<Item>(gBook.Items);
                    IsRefreshing = false;
                });
            else IsRefreshing = false;
        }

        //Konstruktor
        public MainViewModel()
        {
            BookList = new ObservableCollection<Item>();

            SearchCommand = new Command(SearchBooks);
        }

    }
}
