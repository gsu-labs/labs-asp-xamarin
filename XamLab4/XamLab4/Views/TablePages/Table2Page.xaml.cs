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
    public partial class Table2Page : ContentPage
    {
        public Table2Page()
        {
            InitializeComponent();
        }

        private void SaveSell(object sender, EventArgs e)
        {
            var objTabl2 = (Sell)BindingContext;
            if (!String.IsNullOrEmpty(objTabl2.SellPrice.ToString()))
            {
                App.DateBase.Sell.SaveItem(objTabl2);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteSell(object sender, EventArgs e)
        {
            var objTabl2 = (Sell)BindingContext;
            App.DateBase.Sell.DeleteItem(objTabl2.IdSale);
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}