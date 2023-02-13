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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            //table1List.ItemsSource = App.DateBase.Table1.GetItems();
            //App.DateBase.Product.SaveItem(new Product { Name = "Brelok", IdMake = 1, Material = "Metal", Price = 1000 });
            //App.DateBase.Sell.SaveItem(new Sell { IdProduct = 2, Count = 100, SellPrice = 1234, DateSell = DateTime.Now });
        }

        protected override void OnAppearing()
        {
            table1List.ItemsSource = App.DateBase.Product.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Product selectedProduct = (Product)e.SelectedItem;
            Table1Page table1Page = new Table1Page();
            table1Page.BindingContext = selectedProduct;
            await Navigation.PushAsync(table1Page);
        }
        // обработка нажатия кнопки добавления
        private async void CreateProduct(object sender, EventArgs e)
        {
            Product product1 = new Product();
            Table1Page table1Page = new Table1Page();
            table1Page.BindingContext = product1;
            await Navigation.PushAsync(table1Page);
        }

        private async void SearchProduct(object sender, EventArgs e)
        {
            Search1Page search1Page = new Search1Page();
            await Navigation.PushAsync(search1Page);
        }
        
    }
}