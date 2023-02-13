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
    public partial class Page4 : ContentPage
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void Query1(object sender, EventArgs e)
        {
            var query1 = App.DateBase.Movie.GetItems().Join(App.DateBase.Cinema.GetItems(), a => a.IdCinema, b => b.IdCinema, (a, b) => new { Name = a.Name, Cinema = b.Name, Date = a.Date, Price = a.Price }).Where(a => a.Cinema == entry1.Text);
            listView1.ItemsSource = query1;
            if (query1.Count() > 0)
            {
                grid1.IsVisible = true;
            }
        }

        private void Query2(object sender, EventArgs e)
        {
            var query2 = App.DateBase.Movie.GetItems().Where(a => a.Price < Int32.Parse(entry2.Text));
            listView2.ItemsSource = query2;
            if (query2.Count() > 0)
            {
                grid2.IsVisible = true;
            }
        }

        private void Query3(object sender, EventArgs e)
        {
            var query3 = App.DateBase.Movie.GetItems().Join(App.DateBase.Sell.GetItems(), a => a.IdMovie, b => b.IdMovie, (a, b) => new { Name = a.Name, Count = b.Count, Price = a.Price, DateSell = b.DateSell });
            query3 = query3.Where(a => a.DateSell.Year == Int32.Parse(entry3.Text));
            int count = query3.Sum(a => a.Price);

            listView3.ItemsSource = query3;
            if (query3.Count() > 0)
            {
                grid3.IsVisible = true;
                labeLSumPrice.Text = "Общая стоимость: " + count;
            }
        }

        private void Query4(object sender, EventArgs e)
        {
            var query4 = App.DateBase.Movie.GetItems().Where(a => a.Date.ToShortDateString() == entry4.Text);
            listView4.ItemsSource = query4;
            if (query4.Count() > 0)
            {
                grid4.IsVisible = true;
            }
        }

        private void Query5(object sender, EventArgs e)
        {
            var query5 = App.DateBase.Movie.GetItems().Join(App.DateBase.Cinema.GetItems(), a => a.IdCinema, b => b.IdCinema, (a, b) => new { Name = a.Name, Date = a.Date.ToShortDateString(), Price = a.Price, NameCinema = b.Name, idMovie = a.IdMovie }).Join(App.DateBase.Sell.GetItems(), a => a.idMovie, b => b.IdMovie, (a, b) => new { Name = a.Name, NameCinema = a.NameCinema, Date = a.Date, Price = a.Price, Count = b.Count });
            query5 = query5.Where(a => a.NameCinema == entry5.Text);
            listView5.ItemsSource = query5;
            if (query5.Count() > 0)
            {
                grid5.IsVisible = true;
            }
        }
    }
}