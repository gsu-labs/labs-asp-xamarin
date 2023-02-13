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
    public partial class Table1Page : ContentPage
    {
        public Table1Page()
        {
            InitializeComponent();
        }
        private void SaveProduct(object sender, EventArgs e)
        {
            var objTabl1 = (Movie)BindingContext;
            if (!String.IsNullOrEmpty(objTabl1.Name))
            {
                App.DateBase.Movie.SaveItem(objTabl1);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteProduct(object sender, EventArgs e)
        {
            var objTabl1 = (Movie)BindingContext;
            App.DateBase.Movie.DeleteItem(objTabl1.IdMovie);
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}