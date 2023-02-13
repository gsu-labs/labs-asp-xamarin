using SXamLab3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SXamLab3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GardenPage : ContentPage
    {
        public GardenViewModel ViewModel { get; private set; }
        public GardenPage(GardenViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}