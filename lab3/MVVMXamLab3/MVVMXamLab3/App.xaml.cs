using MVVMXamLab3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMXamLab3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SouvenirsListPage());
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
