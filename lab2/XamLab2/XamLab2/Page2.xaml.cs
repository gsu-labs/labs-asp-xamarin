using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace XamLab2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public ObservableCollection<Grouping<string, Souvenir>> SouvenirsGroups { get; set; }
        //ListView listView;
        public Page2()
        {
            InitializeComponent();
            GroupsAndUpdate();
            Page1.Souvenirs.CollectionChanged += Souvenirs_CollectionChanged;
        }

        private void Souvenirs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            GroupsAndUpdate();
        }

        private void GroupsAndUpdate()
        {
            var groups = Page1.Souvenirs.GroupBy(a => a.Maker).Select(a => new Grouping<string, Souvenir>(a.Key, a));
            SouvenirsGroups = new ObservableCollection<Grouping<string, Souvenir>>(groups);
            this.BindingContext = null;
            this.BindingContext = this;
        }
    }
}