using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X_Forms.PersonenDb.Services;

//vgl. AndroidDatabaseService.cs
[assembly: Xamarin.Forms.Dependency(typeof(X_Forms.Droid.Services.AndroidToastService))]
namespace X_Forms.Droid.Services
{
    public class AndroidToastService : IToastService
    {
        public void ShowLong(string msg)
        {
            Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Long).Show();
        }

        public void ShowShort(string msg)
        {
            Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Short).Show();
        }
    }
}