using SHXamLab4.Repository;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHXamLab4
{
    public partial class App : Application
    {
        const string DATABASE_NAME = "movies.db";
        private static DataAccess dateBase;
        public static DataAccess DateBase
        {
            get
            {
                if (dateBase == null)
                {
                    dateBase = new DataAccess(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }

                return dateBase;
            }
        }

        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new MainPage());
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
