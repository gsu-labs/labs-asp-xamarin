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
    public partial class Table3Page : ContentPage
    {
        public Table3Page()
        {
            InitializeComponent();
        }

        private void SaveMaker(object sender, EventArgs e)
        {
            var objTabl3 = (Maker)BindingContext;
            if (!String.IsNullOrEmpty(objTabl3.Name))
            {
                App.DateBase.Maker.SaveItem(objTabl3);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteMaker(object sender, EventArgs e)
        {
            var objTabl3 = (Maker)BindingContext;
            App.DateBase.Maker.DeleteItem(objTabl3.IdMake);
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}