using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamLab4.Models;
using XamLab4.Views.SearchPages;

namespace XamLab4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            table3List.ItemsSource = App.DateBase.Maker.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Maker selectedMaker = (Maker)e.SelectedItem;
            Table3Page table3Page = new Table3Page();
            table3Page.BindingContext = selectedMaker;
            await Navigation.PushAsync(table3Page);
        }
        // обработка нажатия кнопки добавления
        private async void CreateMaker(object sender, EventArgs e)
        {
            Maker maker = new Maker();
            Table3Page table3Page = new Table3Page();
            table3Page.BindingContext = maker;
            await Navigation.PushAsync(table3Page);
        }

        private async void SearchMaker(object sender, EventArgs e)
        {
            Search3Page search3Page = new Search3Page();
            await Navigation.PushAsync(search3Page);
        }
    }
}