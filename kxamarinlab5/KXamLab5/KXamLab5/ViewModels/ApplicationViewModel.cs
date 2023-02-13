using KXamLab5.Models;
using KXamLab5.Services;
using KXamLab5.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KXamLab5.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;
        Wallpaper selectedWallpaper;
        private bool isBusy;

        public ObservableCollection<Wallpaper> Wallpapers { get; set; }
        WallpaperService wallpaperService = new WallpaperService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateWallpaperCommand { protected set; get; }
        public ICommand DeleteWallpaperCommand { protected set; get; }
        public ICommand SaveWallpaperCommand { protected set; get; }
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
            Wallpapers = new ObservableCollection<Wallpaper>();
            IsBusy = false;
            CreateWallpaperCommand = new Command(CreateWallpaper);
            DeleteWallpaperCommand = new Command(DeleteWallpaper);
            SaveWallpaperCommand = new Command(SaveWallpaper);
            BackCommand = new Command(Back);
        }

        public Wallpaper SelectedWallpaper
        {
            get { return selectedWallpaper; }
            set
            {
                if (selectedWallpaper != value)
                {
                    Wallpaper tempWallpaper = new Wallpaper()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Maker = value.Maker,
                        Price = value.Price,
                        DataSell = value.DataSell,
                        Email = value.Email,
                        Phone = value.Phone
                    };
                    selectedWallpaper = null;
                    OnPropertyChanged("SelectedWallpaper");
                    Navigation.PushAsync(new WallpaperPage(tempWallpaper, this));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateWallpaper()
        {
            await Navigation.PushAsync(new WallpaperPage(new Wallpaper(), this));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }

        public async Task GetWallpapers()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Wallpaper> wallpapers = await wallpaperService.Get();

            // очищаем список
            while (Wallpapers.Any())
                Wallpapers.RemoveAt(Wallpapers.Count - 1);

            // добавляем загруженные данные
            foreach (Wallpaper s in wallpapers)
                Wallpapers.Add(s);
            IsBusy = false;
            initialized = true;
        }
        private async void SaveWallpaper(object wallpaperObject)
        {
            Wallpaper wallpaper = wallpaperObject as Wallpaper;
            if (wallpaper != null)
            {
                IsBusy = true;
                // редактирование
                if (wallpaper.Id > 0)
                {
                    Wallpaper updatedWallpaper = await wallpaperService.Update(wallpaper);
                    // заменяем объект в списке на новый
                    if (updatedWallpaper != null)
                    {
                        int pos = Wallpapers.IndexOf(updatedWallpaper);
                        Wallpapers.RemoveAt(pos);
                        Wallpapers.Insert(pos, updatedWallpaper);
                    }
                }
                // добавление
                else
                {
                    Wallpaper addedWallpaper = await wallpaperService.Add(wallpaper);
                    if (addedWallpaper != null)
                        Wallpapers.Add(addedWallpaper);
                }
                IsBusy = false;
            }
            Back();
        }
        private async void DeleteWallpaper(object wallpaperObject)
        {
            Wallpaper wallpaper = wallpaperObject as Wallpaper;
            if (wallpaper != null)
            {
                IsBusy = true;
                Wallpaper deletedWallpaper = await wallpaperService.Delete(wallpaper.Id);
                if (deletedWallpaper != null)
                {
                    Wallpapers.Remove(deletedWallpaper);
                }
                IsBusy = false;
            }
            Back();
        }
    }
}
