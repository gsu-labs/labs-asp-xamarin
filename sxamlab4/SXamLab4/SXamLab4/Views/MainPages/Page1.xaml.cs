using SXamLab4.Models;
using SXamLab4.Views.SearchPages;
using SXamLab4.Views.TablePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SXamLab4.Views.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            table1List.ItemsSource = App.DateBase.Product.GetItems();
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Product selectedProduct = (Product)e.SelectedItem;
            Table1Page table1Page = new Table1Page();
            table1Page.BindingContext = selectedProduct;
            await Navigation.PushAsync(table1Page);
        }

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