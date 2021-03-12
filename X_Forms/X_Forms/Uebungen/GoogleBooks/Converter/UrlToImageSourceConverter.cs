using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.Uebungen.GoogleBooks.Converter
{
    public class UrlToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           ImageSource source = ImageSource.FromUri(new Uri(value.ToString()));
           //ImageSource source = ImageSource.FromUri(new Uri("https://aka.ms/campus.jpg"));

            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
