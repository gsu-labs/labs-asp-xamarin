﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamLab4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search1Page : ContentPage
    {
        public Search1Page()
        {
            InitializeComponent();
        }

        private void SearchFromTable1(object sender, EventArgs e)
        {
            var obj = App.DateBase.Product.GetItems().Where(a=>a.Name == entry1.Text);
            table1List.ItemsSource = obj;
        }
    }
}