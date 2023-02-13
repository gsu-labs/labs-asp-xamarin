using SHXamLab4.Models;
using SHXamLab4.Views.SearchPages;
using SHXamLab4.Views.TablePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHXamLab4.Views.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            table2List.ItemsSource = App.DateBase.Sell.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Sell selectedSell = (Sell)e.SelectedItem;
            Table2Page table2Page = new Table2Page();
            table2Page.BindingContext = selectedSell;
            await Navigation.PushAsync(table2Page);
        }
        // обработка нажатия кнопки добавления
        private async void CreateSell(object sender, EventArgs e)
        {
            Sell sell = new Sell();
            Table2Page table2Page = new Table2Page();
            table2Page.BindingContext = sell;
            await Navigation.PushAsync(table2Page);
        }

        private async void SearchSell(object sender, EventArgs e)
        {
            Search2Page search2Page = new Search2Page();
            await Navigation.PushAsync(search2Page);
        }
    }
}