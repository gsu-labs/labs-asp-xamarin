using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamLab4.Views.SearchPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search3Page : ContentPage
    {
        public Search3Page()
        {
            InitializeComponent();
        }

        private void SearchFromTable3(object sender, EventArgs e)
        {
            var obj = App.DateBase.Maker.GetItems().Where(a => a.Name == entry1.Text);
            table3List.ItemsSource = obj;
        }
    }
}