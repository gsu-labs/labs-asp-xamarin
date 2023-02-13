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
    public partial class WallpaperPage : ContentPage
    {
        public WallpaperViewModel ViewModel { get; private set; }
        public WallpaperPage(WallpaperViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}