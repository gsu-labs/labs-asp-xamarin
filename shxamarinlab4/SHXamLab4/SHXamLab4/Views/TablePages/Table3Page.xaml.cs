using SHXamLab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHXamLab4.Views.TablePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Table3Page : ContentPage
    {
        public Table3Page()
        {
            InitializeComponent();
        }

        private void SaveMaker(object sender, EventArgs e)
        {
            var objTabl3 = (Cinema)BindingContext;
            if (!String.IsNullOrEmpty(objTabl3.Name))
            {
                App.DateBase.Cinema.SaveItem(objTabl3);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteMaker(object sender, EventArgs e)
        {
            var objTabl3 = (Cinema)BindingContext;
            App.DateBase.Cinema.DeleteItem(objTabl3.IdCinema);
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}