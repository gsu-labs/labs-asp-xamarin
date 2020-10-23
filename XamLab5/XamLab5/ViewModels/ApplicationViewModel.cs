using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamLab5
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;
        Souvenir selectedSouvenir;
        private bool isBusy;

        public ObservableCollection<Souvenir> Souvenirs { get; set; }
        SouvenirService souvenirService = new SouvenirService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateSouvenirCommand { protected set; get; }
        public ICommand DeleteSouvenirCommand { protected set; get; }
        public ICommand SaveSouvenirCommand { protected set; get; }
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
            Souvenirs = new ObservableCollection<Souvenir>();
            IsBusy = false;
            CreateSouvenirCommand = new Command(CreateSouvenir);
            DeleteSouvenirCommand = new Command(DeleteSouvenir);
            SaveSouvenirCommand = new Command(SaveSouvenir);
            BackCommand = new Command(Back);
        }

        public Souvenir SelectedSouvenir
        {
            get { return selectedSouvenir; }
            set
            {
                if (selectedSouvenir != value)
                {
                    Souvenir tempSouvenir = new Souvenir()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Maker = value.Maker,
                        Price = value.Price,
                        DataSell = value.DataSell,
                        Email = value.Email,
                        Phone = value.Phone
                    };
                    selectedSouvenir = null;
                    OnPropertyChanged("SelectedSouvenir");
                    Navigation.PushAsync(new SouvenirPage(tempSouvenir, this));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateSouvenir()
        {
            await Navigation.PushAsync(new SouvenirPage(new Souvenir(), this));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }

        public async Task GetSouvenirs()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Souvenir> souvenirs = await souvenirService.Get();

            // очищаем список
            //Souvenirs.Clear();
            while (Souvenirs.Any())
                Souvenirs.RemoveAt(Souvenirs.Count - 1);

            // добавляем загруженные данные
            foreach (Souvenir s in souvenirs)
                Souvenirs.Add(s);
            IsBusy = false;
            initialized = true;
        }
        private async void SaveSouvenir(object souvenirObject)
        {
            Souvenir souvenir = souvenirObject as Souvenir;
            if (souvenir != null)
            {
                IsBusy = true;
                // редактирование
                if (souvenir.Id > 0)
                {
                    Souvenir updatedSouvenir = await souvenirService.Update(souvenir);
                    // заменяем объект в списке на новый
                    if (updatedSouvenir != null)
                    {
                        int pos = Souvenirs.IndexOf(updatedSouvenir);
                        Souvenirs.RemoveAt(pos);
                        Souvenirs.Insert(pos, updatedSouvenir);
                    }
                }
                // добавление
                else
                {
                    Souvenir addedSouvenir = await souvenirService.Add(souvenir);
                    if (addedSouvenir != null)
                        Souvenirs.Add(addedSouvenir);
                }
                IsBusy = false;
            }
            Back();
        }
        private async void DeleteSouvenir(object souvenirObject)
        {
            Souvenir souvenir = souvenirObject as Souvenir;
            if (souvenir != null)
            {
                IsBusy = true;
                Souvenir deletedSouvenir = await souvenirService.Delete(souvenir.Id);
                if (deletedSouvenir != null)
                {
                    Souvenirs.Remove(deletedSouvenir);
                }
                IsBusy = false;
            }
            Back();
        }
    }
}
