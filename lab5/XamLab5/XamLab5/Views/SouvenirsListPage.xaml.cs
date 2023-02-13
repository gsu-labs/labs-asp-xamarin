using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamLab5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SouvenirsListPage : ContentPage
    {
        ApplicationViewModel viewModel;
        public SouvenirsListPage()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetSouvenirs();
            base.OnAppearing();
        }
    }
}