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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            table1List.ItemsSource = App.DateBase.Movie.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Movie selectedMovie = (Movie)e.SelectedItem;
            Table1Page table1Page = new Table1Page();
            table1Page.BindingContext = selectedMovie;
            await Navigation.PushAsync(table1Page);
        }
        // обработка нажатия кнопки добавления
        private async void CreateMovie(object sender, EventArgs e)
        {
            Movie movie1 = new Movie();
            Table1Page table1Page = new Table1Page();
            table1Page.BindingContext = movie1;
            await Navigation.PushAsync(table1Page);
        }

        private async void SearchMovie(object sender, EventArgs e)
        {
            Search1Page search1Page = new Search1Page();
            await Navigation.PushAsync(search1Page);
        }
    }
}