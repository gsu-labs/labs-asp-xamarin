using SHXamLab4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SHXamLab4
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.DateBase.Movie.GetItems().Count() == 0)
            {
                App.DateBase.Movie.SaveItem(new Movie() { Name = "Довод", IdCinema = 2, Date = Convert.ToDateTime("12.08.2020"), Price = 50 });
                App.DateBase.Movie.SaveItem(new Movie() { Name = "Дэдпул", IdCinema = 1, Date = Convert.ToDateTime("10.02.2016"), Price = 45 });
                App.DateBase.Movie.SaveItem(new Movie() { Name = "Зеленая миля", IdCinema = 5, Date = Convert.ToDateTime("06.12.1999"), Price = 43 });
                App.DateBase.Movie.SaveItem(new Movie() { Name = "Мстители: финал", IdCinema = 3, Date = Convert.ToDateTime("25.04.2019"), Price = 60 });
                App.DateBase.Movie.SaveItem(new Movie() { Name = "Платформа", IdCinema = 4, Date = Convert.ToDateTime("21.02.2020"), Price = 37 });

            }
            if (App.DateBase.Sell.GetItems().Count() == 0)
            {
                App.DateBase.Sell.SaveItem(new Sell() { IdMovie = 1, Count = 21422, SellPrice = 632, DateSell = new DateTime(2020, 11, 15) });
                App.DateBase.Sell.SaveItem(new Sell() { IdMovie = 2, Count = 6422, SellPrice = 125, DateSell = new DateTime(2016, 07, 24) });
                App.DateBase.Sell.SaveItem(new Sell() { IdMovie = 3, Count = 8422, SellPrice = 328, DateSell = new DateTime(2000, 06, 10) });
                App.DateBase.Sell.SaveItem(new Sell() { IdMovie = 4, Count = 2156, SellPrice = 1145, DateSell = new DateTime(2019, 11, 09) });
                App.DateBase.Sell.SaveItem(new Sell() { IdMovie = 5, Count = 7564, SellPrice = 412, DateSell = new DateTime(2020, 09, 27) });
            }
            if (App.DateBase.Cinema.GetItems().Count() == 0)
            {
                App.DateBase.Cinema.SaveItem(new Cinema() { Name = "Калинино", Adress = "Улица Вишеная 10А", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Cinema.SaveItem(new Cinema() { Name = "Октябрь", Adress = "Улица Фамильная 23", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Cinema.SaveItem(new Cinema() { Name = "Мир", Adress = "Улица Минская 54", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Cinema.SaveItem(new Cinema() { Name = "Терра", Adress = "Улица Независимости 21B", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Cinema.SaveItem(new Cinema() { Name = "Муви", Adress = "Улица Трудовая 1", Email = "abc@mail.ru", Phone = "375295611264" });
            }
        }
    }
}
