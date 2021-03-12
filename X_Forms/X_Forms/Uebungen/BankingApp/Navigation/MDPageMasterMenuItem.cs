using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsTest.Uebungen.BankingApp_MVVM.Service;
using XamarinFormsTest.Uebungen.BankingApp_MVVM.View;

namespace XamarinFormsTest.Uebungen.BankingApp_MVVM.Navigation
{

    public class MDPageMasterMenuItem
    {
        public MDPageMasterMenuItem()
        {
            TargetType = typeof(MDPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        private Type targetType;
        public Type TargetType
        {
            get
            {
                if (this.Title == "Logout")
                {
                    PersonService.SelectedPerson = null;
                    Application.Current.MainPage = new LoginView();
                    return typeof(LoginView);
                }
                else
                    return targetType;
            }
            set { targetType = value; }
        }
    }
}