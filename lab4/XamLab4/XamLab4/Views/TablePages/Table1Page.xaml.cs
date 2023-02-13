using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamLab4.Models;

namespace XamLab4
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
            var objTabl1 = (Product)BindingContext;
            if (!String.IsNullOrEmpty(objTabl1.Name))
            {
                App.DateBase.Product.SaveItem(objTabl1);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteProduct(object sender, EventArgs e)
        {
            var objTabl1 = (Product)BindingContext;
            App.DateBase.Product.DeleteItem(objTabl1.IdProduct);
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}