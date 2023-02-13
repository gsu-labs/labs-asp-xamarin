using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SXamLab2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public ObservableCollection<Grouping<string, Garden>> GardensGroups { get; set; }
        public Page2()
        {
            InitializeComponent();
            GroupsAndUpdate();
            Page1.Gardens.CollectionChanged += Gardens_CollectionChanged;
        }

        private void Gardens_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            GroupsAndUpdate();
        }

        private void GroupsAndUpdate()
        {
            var groups = Page1.Gardens.GroupBy(a => a.Maker).Select(a => new Grouping<string, Garden>(a.Key, a));
            GardensGroups = new ObservableCollection<Grouping<string, Garden>>(groups);
            this.BindingContext = null;
            this.BindingContext = this;
        }
    }
}