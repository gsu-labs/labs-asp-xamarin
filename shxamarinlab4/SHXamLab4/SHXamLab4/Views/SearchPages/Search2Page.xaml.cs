using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHXamLab4.Views.SearchPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search2Page : ContentPage
    {
        public Search2Page()
        {
            InitializeComponent();
        }

        private void SearchFromTable2(object sender, EventArgs e)
        {
            var obj = App.DateBase.Sell.GetItems().Where(a => a.Count == Int32.Parse(entry1.Text));
            table2List.ItemsSource = obj;
        }
    }
}