using MVVMXamLab3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMXamLab3.ViewModels
{
    public class SouvenirsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SouvenirViewModel> Souvenirs { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateSouvenirCommand { protected set; get; }
        public ICommand DeleteSouvenirCommand { protected set; get; }
        public ICommand SaveSouvenirCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public ICommand MoveToTopCommand { protected set; get; }
        public ICommand MoveToBottomCommand { protected set; get; }
        public ICommand RemoveCommand { protected set; get; }

        SouvenirViewModel selectedSouvenir;
        public INavigation Navigation { get; set; }
        public SouvenirsListViewModel()
        {
            Souvenirs = new ObservableCollection<SouvenirViewModel>()
            {
                new SouvenirViewModel{ Name = "Брелок", Maker = "ABC", Price = 650, Date = Convert.ToDateTime("16.05.2018"), Email="lol@mail.ru", Phone="375295341276", ListViewModel = this},
                new SouvenirViewModel{ Name = "Стеклянный шар", Maker = "ABC", Price = 1000, Date = Convert.ToDateTime("20.10.2020"), Email="aasfg@gmail.com", Phone="375446427812", ListViewModel = this},
                new SouvenirViewModel{ Name = "Майка", Maker = "Vsemayki", Price = 4000, Date = Convert.ToDateTime("11.03.2019"), Email="hree@gmail.com", Phone="375359741204", ListViewModel = this},
                new SouvenirViewModel{ Name = "Флажок", Maker = "Yewa", Price = 400, Date =  Convert.ToDateTime("15.07.2020"), Email="waerqw@mail.ru", Phone="375440781252", ListViewModel = this }
            };
            CreateSouvenirCommand = new Command(CreateSouvenir);
            DeleteSouvenirCommand = new Command(DeleteSouvenir);
            SaveSouvenirCommand = new Command(SaveSouvenir);
            BackCommand = new Command(Back);


            MoveToTopCommand = new Command(MoveToTop);
            MoveToBottomCommand = new Command(MoveToBottom);
            RemoveCommand = new Command(Remove);
        }

        public SouvenirViewModel SelectedSouvenir
        {
            get { return selectedSouvenir; }
            set
            {
                if(selectedSouvenir != value)
                {
                    SouvenirViewModel tempSouvenir = value;
                    selectedSouvenir = null;
                    OnPropertyChanged("SelectedSouvenir");
                    Navigation.PushAsync(new SouvenirPage(tempSouvenir));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateSouvenir()
        {
            Navigation.PushAsync(new SouvenirPage(new SouvenirViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveSouvenir(object souvenirObject)
        {
            SouvenirViewModel souvenir = souvenirObject as SouvenirViewModel;
            if (souvenir != null && souvenir.IsValid)
            {
                Souvenirs.Add(souvenir);
            }
            Back();
        }
        private void DeleteSouvenir(object souvenirObject)
        {
            SouvenirViewModel souvenir = souvenirObject as SouvenirViewModel;
            if (souvenir != null)
            {
                Souvenirs.Remove(souvenir);
            }
            Back();
        }


        private void MoveToTop(object souvenirObject)
        {
            SouvenirViewModel souvenir = souvenirObject as SouvenirViewModel;
            if (souvenir == null) return;
            int oldIndex = Souvenirs.IndexOf(souvenir);
            if (oldIndex > 0)
                Souvenirs.Move(oldIndex, oldIndex - 1);
        }
        private void MoveToBottom(object souvenirObj)
        {
            SouvenirViewModel souvenir = souvenirObj as SouvenirViewModel;
            if (souvenir == null) return;
            int oldIndex = Souvenirs.IndexOf(souvenir);
            if (oldIndex < Souvenirs.Count - 1)
                Souvenirs.Move(oldIndex, oldIndex + 1);
        }
        private void Remove(object souvenirObj)
        {
            SouvenirViewModel souvenir = souvenirObj as SouvenirViewModel;
            if (souvenir == null) return;

            Souvenirs.Remove(souvenir);
        }
    }
}