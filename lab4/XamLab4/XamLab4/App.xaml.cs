using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamLab4.Models;
using XamLab4.Repository;

namespace XamLab4
{
    public partial class App : Application
    {
        const string DATABASE_NAME = "souvenirs.db";
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
            //SQLiteConnection sQLiteConnection = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
            //sQLiteConnection.DropTable<Product>();
            //sQLiteConnection.DropTable<Sell>();
            //sQLiteConnection.DropTable<Maker>();
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
