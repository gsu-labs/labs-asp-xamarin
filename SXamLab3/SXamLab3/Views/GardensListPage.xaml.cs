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
    public partial class GardensListPage : ContentPage
    {
        public GardensListPage()
        {
            InitializeComponent();
            BindingContext = new GardensListViewModel() { Navigation = this.Navigation };
        }
    }
}