
using Newtonsoft.Json;
using System.ComponentModel;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace X_Forms.Uebungen.GoogleBooks.Model
{
    public partial class ImageLinks : INotifyPropertyChanged
    {
        private string smallThumbnail;

        [JsonProperty("smallThumbnail")]
        public string SmallThumbnail { get => smallThumbnail; set { smallThumbnail = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SmallThumbnail))); } }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

