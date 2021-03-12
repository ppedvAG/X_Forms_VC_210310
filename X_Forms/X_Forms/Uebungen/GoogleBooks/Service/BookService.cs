using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using X_Forms.Uebungen.GoogleBooks.Model;

namespace X_Forms.Uebungen.GoogleBooks.Service
{
    //Service-Klasse zum Zugriff auf GoogleBooks
    public static class BookService
    {
        public static GBook FindBooks(string searchstring)
        {
            string json;

            using (WebClient client = new WebClient())
            {
                //WebClient läd Bücherliste herunter
                json = client.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={searchstring}");
            }

            //Json deserialisiert den String in Model-Objekte
            return JsonConvert.DeserializeObject<GBook>(json);
        }
    }
}
