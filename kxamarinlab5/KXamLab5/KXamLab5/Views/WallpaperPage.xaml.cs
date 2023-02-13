using KXamLab5.Models;
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
    public partial class WallpaperPage : ContentPage
    {
        public Wallpaper Model { get; private set; }
        public ApplicationViewModel ViewModel { get; private set; }
        public WallpaperPage(Wallpaper model, ApplicationViewModel viewModel)
        {
            InitializeComponent();
            Model = model;
            ViewModel = viewModel;
            this.BindingContext = this;
        }
    }
}