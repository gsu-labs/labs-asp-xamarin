using KXamLab5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KXamLab5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WallpaperListPage : ContentPage
    {
        ApplicationViewModel viewModel;
        public WallpaperListPage()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetWallpapers();
            base.OnAppearing();
        }
    }
}