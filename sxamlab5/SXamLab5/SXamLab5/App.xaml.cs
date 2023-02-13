using SXamLab5.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SXamLab5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new GardensListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
