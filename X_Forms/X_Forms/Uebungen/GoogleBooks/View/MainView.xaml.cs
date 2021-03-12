using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.Uebungen.GoogleBooks.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ImageSource source = ImageSource.FromUri(new Uri((LstV_Books.SelectedItem as Model.Item).VolumeInfo.ImageLinks.SmallThumbnail));
            Img_Test.Source = source;

            LstV_Books.IsVisible = false;
            Img_Test.IsVisible = true;
        }
    }
}