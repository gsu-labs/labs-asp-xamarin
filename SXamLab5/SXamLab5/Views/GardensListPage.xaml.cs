using SXamLab5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SXamLab5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GardensListPage : ContentPage
    {
        ApplicationViewModel viewModel;
        public GardensListPage()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetGardens();
            base.OnAppearing();
        }
    }
}