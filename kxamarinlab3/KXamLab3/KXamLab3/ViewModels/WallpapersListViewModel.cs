using KXamLab3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KXamLab3.ViewModels
{
    public class WallpapersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<WallpaperViewModel> Wallpapers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateWallpaperCommand { protected set; get; }
        public ICommand DeleteWallpaperCommand { protected set; get; }
        public ICommand SaveWallpaperCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public ICommand MoveToTopCommand { protected set; get; }
        public ICommand MoveToBottomCommand { protected set; get; }
        public ICommand RemoveCommand { protected set; get; }

        WallpaperViewModel selectedWallpaper;
        public INavigation Navigation { get; set; }
        public WallpapersListViewModel()
        {
            Wallpapers = new ObservableCollection<WallpaperViewModel>()
            {
                new WallpaperViewModel{ Name = "Белобои Кирпичики", Maker = "Минская обойная фабрика", Price = 45, Date = Convert.ToDateTime("11.04.2019"), Email="asfa@mail.ru", Phone="375295371276", ListViewModel = this},
                new WallpaperViewModel{ Name = "Белобои Лаванда", Maker = "Волсти", Price = 23, Date = Convert.ToDateTime("19.07.2020"), Email="rhter@gmail.com", Phone="375440427812", ListViewModel = this},
                new WallpaperViewModel{ Name = "Батик", Maker = "Гомельобои", Price = 50, Date = Convert.ToDateTime("15.07.2020"), Email="frte@gmail.com", Phone="375355741204", ListViewModel = this},
                new WallpaperViewModel{ Name = "Принты", Maker = "Клерен", Price = 76, Date =  Convert.ToDateTime("03.09.2021"), Email="ghe@mail.ru", Phone="375440981252", ListViewModel = this }
            };
            CreateWallpaperCommand = new Command(CreateWallpaper);
            DeleteWallpaperCommand = new Command(DeleteWallpaper);
            SaveWallpaperCommand = new Command(SaveWallpaper);
            BackCommand = new Command(Back);


            MoveToTopCommand = new Command(MoveToTop);
            MoveToBottomCommand = new Command(MoveToBottom);
            RemoveCommand = new Command(Remove);
        }

        public WallpaperViewModel SelectedWallpaper
        {
            get { return selectedWallpaper; }
            set
            {
                if (selectedWallpaper != value)
                {
                    WallpaperViewModel tempWallpaper = value;
                    selectedWallpaper = null;
                    OnPropertyChanged("SelectedWallpaper");
                    Navigation.PushAsync(new WallpaperPage(tempWallpaper));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateWallpaper()
        {
            Navigation.PushAsync(new WallpaperPage(new WallpaperViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveWallpaper(object wallpaperObject)
        {
            WallpaperViewModel wallpaper = wallpaperObject as WallpaperViewModel;
            if (wallpaper != null && wallpaper.IsValid)
            {
                Wallpapers.Add(wallpaper);
            }
            Back();
        }
        private void DeleteWallpaper(object wallpaperObject)
        {
            WallpaperViewModel wallpaper = wallpaperObject as WallpaperViewModel;
            if (wallpaper != null)
            {
                Wallpapers.Remove(wallpaper);
            }
            Back();
        }


        private void MoveToTop(object wallpaperObject)
        {
            WallpaperViewModel wallpaper =wallpaperObject as WallpaperViewModel;
            if (wallpaper == null) return;
            int oldIndex = Wallpapers.IndexOf(wallpaper);
            if (oldIndex > 0)
                Wallpapers.Move(oldIndex, oldIndex - 1);
        }
        private void MoveToBottom(object wallpaperObj)
        {
            WallpaperViewModel wallpaper = wallpaperObj as WallpaperViewModel;
            if (wallpaper == null) return;
            int oldIndex = Wallpapers.IndexOf(wallpaper);
            if (oldIndex < Wallpapers.Count - 1)
                Wallpapers.Move(oldIndex, oldIndex + 1);
        }
        private void Remove(object wallpaperObj)
        {
            WallpaperViewModel wallpaper = wallpaperObj as WallpaperViewModel;
            if (wallpaper == null) return;

            Wallpapers.Remove(wallpaper);
        }
    }
}
