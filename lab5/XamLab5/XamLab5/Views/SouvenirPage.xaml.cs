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
    public partial class SouvenirPage : ContentPage
    {
        public Souvenir Model { get; private set; }
        public ApplicationViewModel ViewModel { get; private set; }
        public SouvenirPage(Souvenir model, ApplicationViewModel viewModel)
        {
            InitializeComponent();
            Model = model;
            ViewModel = viewModel;
            this.BindingContext = this;
        }
    }
}