using SXamLab4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SXamLab4
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.DateBase.Product.GetItems().Count() == 0)
            {
                App.DateBase.Product.SaveItem(new Product() { Name = "Одноколёсная тачка", IdMake = 2, Material = "Железо", Price = 86 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Лопата штыковая", IdMake = 1, Material = "Алюминй", Price = 40 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Грабли веерные", IdMake = 5, Material = "Алюминий", Price = 20 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Топор-колун", IdMake = 3, Material = "Железо", Price = 131 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Пила", IdMake = 4, Material = "Железо", Price = 50 });

            }
            if (App.DateBase.Sell.GetItems().Count() == 0)
            {
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 1, Count = 23535, SellPrice = 95, DateSell = new DateTime(2019, 12, 07) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 2, Count = 64212, SellPrice = 60, DateSell = new DateTime(2020, 04, 03) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 3, Count = 6532, SellPrice = 30, DateSell = new DateTime(2020, 04, 16) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 4, Count = 2343, SellPrice = 150, DateSell = new DateTime(2018, 02, 01) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 5, Count = 7651, SellPrice = 80, DateSell = new DateTime(2021, 11, 02) });
            }
            if (App.DateBase.Maker.GetItems().Count() == 0)
            {
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Альфасто", Adress = "Улица Вишеная 10А", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "STARTUL", Adress = "Улица Фамильная 23", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Fiskars", Adress = "Улица Минская 54", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Fiskars", Adress = "Улица Независимости 21B", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Karant", Adress = "Улица Трудовая 1", Email = "abc@mail.ru", Phone = "375295611264" });
            }
        }
    }
}
