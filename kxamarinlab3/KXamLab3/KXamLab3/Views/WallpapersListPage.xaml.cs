using KXamLab3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KXamLab3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WallpapersListPage : ContentPage
    {
        public WallpapersListPage()
        {
            InitializeComponent();
            BindingContext = new WallpapersListViewModel() { Navigation = this.Navigation };
        }
    }
}