using KXamLab3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KXamLab3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WallpapersListPage());
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
