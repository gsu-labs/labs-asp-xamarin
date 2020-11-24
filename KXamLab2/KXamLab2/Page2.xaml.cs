using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KXamLab2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public ObservableCollection<Grouping<string, Wallpaper>> WallpapersGroups { get; set; }
        public Page2()
        {
            InitializeComponent();
            GroupsAndUpdate();
            Page1.Wallpapers.CollectionChanged += Souvenirs_CollectionChanged;
        }

        private void Souvenirs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            GroupsAndUpdate();
        }

        private void GroupsAndUpdate()
        {
            var groups = Page1.Wallpapers.GroupBy(a => a.Maker).Select(a => new Grouping<string, Wallpaper>(a.Key, a));
            WallpapersGroups = new ObservableCollection<Grouping<string, Wallpaper>>(groups);
            this.BindingContext = null;
            this.BindingContext = this;
        }
    }
}