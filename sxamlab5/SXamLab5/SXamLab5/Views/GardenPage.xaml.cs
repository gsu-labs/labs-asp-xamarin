using SXamLab5.Models;
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
    public partial class GardenPage : ContentPage
    {
        public Garden Model { get; private set; }
        public ApplicationViewModel ViewModel { get; private set; }
        public GardenPage(Garden model, ApplicationViewModel viewModel)
        {
            InitializeComponent();
            Model = model;
            ViewModel = viewModel;
            this.BindingContext = this;
        }
    }
}