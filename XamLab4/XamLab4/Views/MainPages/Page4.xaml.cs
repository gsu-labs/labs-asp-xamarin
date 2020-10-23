using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace XamLab4
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
            var query1 = App.DateBase.Product.GetItems().Join(App.DateBase.Maker.GetItems(), a => a.IdMake, b => b.IdMake, (a, b) => new { Name = a.Name, Maker = b.Name, Material = a.Material, Price = a.Price }).Where(a=>a.Maker == entry1.Text);
            listView1.ItemsSource = query1;
            if(query1.Count() > 0)
            {
                grid1.IsVisible = true;
            }
        }

        private void Query2(object sender, EventArgs e)
        {
            var query2 = App.DateBase.Product.GetItems().Where(a => a.Price < Int32.Parse(entry2.Text));
            listView2.ItemsSource = query2;
            if (query2.Count() > 0)
            {
                grid2.IsVisible = true;
            }
        }

        private void Query3(object sender, EventArgs e)
        {
            var query3 = App.DateBase.Product.GetItems().Join(App.DateBase.Sell.GetItems(), a => a.IdProduct, b => b.IdProduct, (a,b) => new { Name = a.Name, Count = b.Count, Price = a.Price, DateSell = b.DateSell });
            query3 = query3.Where(a => a.DateSell.Year == Int32.Parse(entry3.Text));
            int count = query3.Sum(a=>a.Price);
            
            listView3.ItemsSource = query3;
            if (query3.Count() > 0)
            {
                grid3.IsVisible = true;
                labeLSumPrice.Text = "Общая стоимость: " + count;
            }
        }

        private void Query4(object sender, EventArgs e)
        {
            var query4 = App.DateBase.Product.GetItems().Where(a=>a.Material == entry4.Text);
            listView4.ItemsSource = query4;
            if (query4.Count() > 0)
            {
                grid4.IsVisible = true;
            }
        }

        private void Query5(object sender, EventArgs e)
        {
            var query5 = App.DateBase.Product.GetItems().Join(App.DateBase.Maker.GetItems(), a => a.IdMake, b => b.IdMake, (a, b) => new { Name = a.Name, Material = a.Material,  Price = a.Price, NameMaker = b.Name, idProduct = a.IdProduct}).Join(App.DateBase.Sell.GetItems(), a=>a.idProduct, b=>b.IdProduct,(a,b)=>new { Name = a.Name, NameMaker = a.NameMaker, Material = a.Material, Price = a.Price, Count = b.Count });
            query5 = query5.Where(a => a.NameMaker == entry5.Text);
            listView5.ItemsSource = query5;
            if (query5.Count() > 0)
            {
                grid5.IsVisible = true;
            }
        }
    }
}