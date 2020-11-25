using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHXamLab2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public ObservableCollection<Grouping<string, Movie>> MoviesGroups { get; set; }
        public Page2()
        {
            InitializeComponent();
            GroupsAndUpdate();
            Page1.Movies.CollectionChanged += Movies_CollectionChanged;
        }

        private void Movies_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            GroupsAndUpdate();
        }

        private void GroupsAndUpdate()
        {
            var groups = Page1.Movies.GroupBy(a => a.Genre).Select(a => new Grouping<string, Movie>(a.Key, a));
            MoviesGroups = new ObservableCollection<Grouping<string, Movie>>(groups);
            this.BindingContext = null;
            this.BindingContext = this;
        }
    }
}