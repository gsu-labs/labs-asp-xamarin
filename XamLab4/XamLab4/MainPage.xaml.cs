using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamLab4.Models;

namespace XamLab4
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.DateBase.Product.GetItems().Count() == 0)
            {
                App.DateBase.Product.SaveItem(new Product() { Name="Брелок", IdMake=2, Material="Металл", Price=300});
                App.DateBase.Product.SaveItem(new Product() { Name = "Флаг", IdMake = 1, Material = "Ткань", Price = 500 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Кружка", IdMake = 5, Material = "Стекло", Price = 430 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Кольцо", IdMake = 3, Material = "Золото", Price = 1000 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Машинка", IdMake = 4, Material = "Металл", Price = 300 });

            }
            if (App.DateBase.Sell.GetItems().Count() == 0)
            {
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct=1, Count=10000, SellPrice=350, DateSell = new DateTime(2019, 10, 10)});
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 2, Count = 21452, SellPrice = 550, DateSell = new DateTime(2021, 05, 12) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 3, Count = 5132, SellPrice = 460, DateSell = new DateTime(2020, 03, 09) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 4, Count = 1475, SellPrice = 1200, DateSell = new DateTime(2018, 01, 01) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 5, Count = 2153, SellPrice = 350, DateSell = new DateTime(2020, 07, 21) });
            }
            if (App.DateBase.Maker.GetItems().Count() == 0)
            {
                App.DateBase.Maker.SaveItem(new Maker() { Name="ABC", Adress="Улица Вишеная 10А", Email="abc@mail.ru", Phone="375295611264"});
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Парадокс", Adress = "Улица Фамильная 23", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Unicorn", Adress = "Улица Минская 54", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Слэща", Adress = "Улица Независимости 21B", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Sover", Adress = "Улица Трудовая 1", Email = "abc@mail.ru", Phone = "375295611264" });
            }
        }
    }
}
