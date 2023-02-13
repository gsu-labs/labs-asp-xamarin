using SXamLab3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SXamLab3.ViewModels
{
    public class GardensListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GardenViewModel> Gardens { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateGardenCommand { protected set; get; }
        public ICommand DeleteGardenCommand { protected set; get; }
        public ICommand SaveGardenCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public ICommand MoveToTopCommand { protected set; get; }
        public ICommand MoveToBottomCommand { protected set; get; }
        public ICommand RemoveCommand { protected set; get; }

        GardenViewModel selectedGarden;
        public INavigation Navigation { get; set; }
        public GardensListViewModel()
        {
            Gardens = new ObservableCollection<GardenViewModel>()
            {
                new GardenViewModel{ Name = "Одноколёсная тачка", Maker = "Альфасто", Price = 86, Date = Convert.ToDateTime("07.12.2019"), Email="hfd@mail.ru", Phone="375295344276", ListViewModel = this},
                new GardenViewModel{ Name = "Лопата штыковая", Maker = "STARTUL", Price = 40, Date = Convert.ToDateTime("03.04.2020"), Email="aaytg@gmail.com", Phone="375446627812", ListViewModel = this},
                new GardenViewModel{ Name = "Грабли веерные", Maker = "Fiskars", Price = 20, Date = Convert.ToDateTime("16.04.2020"), Email="hrhde@gmail.com", Phone="375359781204", ListViewModel = this},
                new GardenViewModel{ Name = "Топор-колун", Maker = "Fiskars", Price = 131, Date =  Convert.ToDateTime("02.11.2021"), Email="wsarqw@mail.ru", Phone="375440781052", ListViewModel = this }
            };
            CreateGardenCommand = new Command(CreateGarden);
            DeleteGardenCommand = new Command(DeleteGarden);
            SaveGardenCommand = new Command(SaveGarden);
            BackCommand = new Command(Back);


            MoveToTopCommand = new Command(MoveToTop);
            MoveToBottomCommand = new Command(MoveToBottom);
            RemoveCommand = new Command(Remove);
        }

        public GardenViewModel SelectedGarden
        {
            get { return selectedGarden; }
            set
            {
                if (selectedGarden != value)
                {
                    GardenViewModel tempGarden = value;
                    selectedGarden = null;
                    OnPropertyChanged("SelectedGarden");
                    Navigation.PushAsync(new GardenPage(tempGarden));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateGarden()
        {
            Navigation.PushAsync(new GardenPage(new GardenViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveGarden(object gardenObject)
        {
            GardenViewModel garden = gardenObject as GardenViewModel;
            if (garden != null && garden.IsValid)
            {
                Gardens.Add(garden);
            }
            Back();
        }
        private void DeleteGarden(object gardenObject)
        {
            GardenViewModel garden = gardenObject as GardenViewModel;
            if (garden != null)
            {
                Gardens.Remove(garden);
            }
            Back();
        }


        private void MoveToTop(object gardenObject)
        {
            GardenViewModel garden = gardenObject as GardenViewModel;
            if (garden == null) return;
            int oldIndex = Gardens.IndexOf(garden);
            if (oldIndex > 0)
                Gardens.Move(oldIndex, oldIndex - 1);
        }
        private void MoveToBottom(object gardenObject)
        {
            GardenViewModel garden = gardenObject as GardenViewModel;
            if (garden == null) return;
            int oldIndex = Gardens.IndexOf(garden);
            if (oldIndex < Gardens.Count - 1)
                Gardens.Move(oldIndex, oldIndex + 1);
        }
        private void Remove(object gardenObject)
        {
            GardenViewModel garden = gardenObject as GardenViewModel;
            if (garden == null) return;

            Gardens.Remove(garden);
        }
    }
}
