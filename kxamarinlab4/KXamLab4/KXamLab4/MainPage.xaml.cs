using KXamLab4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KXamLab4
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.DateBase.Product.GetItems().Count() == 0)
            {
                App.DateBase.Product.SaveItem(new Product() { Name = "Белобои Кирпичики", IdMake = 2, Material = "Бумажные ", Price = 45 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Белобои Лаванда", IdMake = 1, Material = "Флизелиновые ", Price = 50 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Батик", IdMake = 5, Material = "Виниловые ", Price = 43 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Принты", IdMake = 3, Material = "Бумажные ", Price = 50 });
                App.DateBase.Product.SaveItem(new Product() { Name = "Ляртик", IdMake = 4, Material = "Виниловые ", Price = 25 });

            }
            if (App.DateBase.Sell.GetItems().Count() == 0)
            {
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 1, Count = 10000, SellPrice = 50, DateSell = new DateTime(2019, 04, 11) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 2, Count = 21452, SellPrice = 55, DateSell = new DateTime(2020, 07, 19) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 3, Count = 5132, SellPrice = 46, DateSell = new DateTime(2020, 07, 15) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 4, Count = 1475, SellPrice = 70, DateSell = new DateTime(2021, 09, 03) });
                App.DateBase.Sell.SaveItem(new Sell() { IdProduct = 5, Count = 2153, SellPrice = 40, DateSell = new DateTime(2020, 03, 03) });
            }
            if (App.DateBase.Maker.GetItems().Count() == 0)
            {
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Минская обойная фабрика", Adress = "Улица Вишеная 10А", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Волсти", Adress = "Улица Фамильная 23", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Гомельобои", Adress = "Улица Минская 54", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Клерен", Adress = "Улица Независимости 21B", Email = "abc@mail.ru", Phone = "375295611264" });
                App.DateBase.Maker.SaveItem(new Maker() { Name = "Дарма", Adress = "Улица Трудовая 1", Email = "abc@mail.ru", Phone = "375295611264" });
            }
        }
    }
}
