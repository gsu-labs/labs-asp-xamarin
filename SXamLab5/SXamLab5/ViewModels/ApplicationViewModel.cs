using SXamLab5.Models;
using SXamLab5.Services;
using SXamLab5.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SXamLab5.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;
        Garden selectedGarden;
        private bool isBusy;

        public ObservableCollection<Garden> Gardens { get; set; }
        GardenService gardenService = new GardenService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateGardenCommand { protected set; get; }
        public ICommand DeleteGardenCommand { protected set; get; }
        public ICommand SaveGardenCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }

        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ApplicationViewModel()
        {
            Gardens = new ObservableCollection<Garden>();
            IsBusy = false;
            CreateGardenCommand = new Command(CreateGarden);
            DeleteGardenCommand = new Command(DeleteGarden);
            SaveGardenCommand = new Command(SaveGarden);
            BackCommand = new Command(Back);
        }

        public Garden SelectedGarden
        {
            get { return selectedGarden; }
            set
            {
                if (selectedGarden != value)
                {
                    Garden tempGarden = new Garden()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Maker = value.Maker,
                        Price = value.Price,
                        DataSell = value.DataSell,
                        Email = value.Email,
                        Phone = value.Phone
                    };
                    selectedGarden = null;
                    OnPropertyChanged("SelectedGarden");
                    Navigation.PushAsync(new GardenPage(tempGarden, this));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateGarden()
        {
            await Navigation.PushAsync(new GardenPage(new Garden(), this));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }

        public async Task GetGardens()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Garden> gardens = await gardenService.Get();


            while (Gardens.Any())
                Gardens.RemoveAt(Gardens.Count - 1);

            foreach (Garden s in gardens)
                Gardens.Add(s);
            IsBusy = false;
            initialized = true;
        }
        private async void SaveGarden(object gardenObject)
        {
            Garden garden = gardenObject as Garden;
            if (garden != null)
            {
                IsBusy = true;
                if (garden.Id > 0)
                {
                    Garden updatedGarden = await gardenService.Update(garden);
                    // заменяем объект в списке на новый
                    if (updatedGarden != null)
                    {
                        int pos = Gardens.IndexOf(updatedGarden);
                        Gardens.RemoveAt(pos);
                        Gardens.Insert(pos, updatedGarden);
                    }
                }
                else
                {
                    Garden addedGarden = await gardenService.Add(garden);
                    if (addedGarden != null)
                        Gardens.Add(addedGarden);
                }
                IsBusy = false;
            }
            Back();
        }
        private async void DeleteGarden(object gardenObject)
        {
            Garden garden = gardenObject as Garden;
            if (garden != null)
            {
                IsBusy = true;
                Garden deletedGarden = await gardenService.Delete(garden.Id);
                if (deletedGarden != null)
                {
                    Gardens.Remove(deletedGarden);
                }
                IsBusy = false;
            }
            Back();
        }
    }
}
