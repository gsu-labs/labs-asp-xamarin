using Microsoft.Win32.SafeHandles;
using MVVMXamLab3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMXamLab3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SouvenirsListPage : ContentPage
    {
        public SouvenirsListPage()
        {
            InitializeComponent();
            BindingContext = new SouvenirsListViewModel() { Navigation = this.Navigation };
        }
    }
}