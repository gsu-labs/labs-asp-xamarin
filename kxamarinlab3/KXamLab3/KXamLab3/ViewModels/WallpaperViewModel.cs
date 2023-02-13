using KXamLab3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;

namespace KXamLab3.ViewModels
{
    public class WallpaperViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        WallpapersListViewModel lvm;
        public Wallpaper Wallpaper { get; private set; }
        public WallpaperViewModel()
        {
            Wallpaper = new Wallpaper();
        }

        public WallpapersListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return Wallpaper.Name; }
            set
            {
                if (Wallpaper.Name != value)
                {
                    Wallpaper.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Maker
        {
            get { return Wallpaper.Maker; }
            set
            {
                if (Wallpaper.Maker != value)
                {
                    Wallpaper.Maker = value;
                    OnPropertyChanged("Maker");
                }
            }
        }

        public int Price
        {
            get { return Wallpaper.Price; }
            set
            {
                if (Wallpaper.Price != value)
                {
                    Wallpaper.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public DateTime Date
        {
            get { return Wallpaper.Date; }
            set
            {
                if (Wallpaper.Date != value)
                {
                    Wallpaper.Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string Email
        {
            get { return Wallpaper.Email; }
            set
            {
                if (Wallpaper.Email != value)
                {
                    try
                    {
                        var mail = new MailAddress(value);
                        Wallpaper.Email = mail.ToString();
                        OnPropertyChanged("Email");
                    }
                    catch
                    {
                        Wallpaper.Email = value + "@mail.ru";
                    }
                }
            }
        }
        public string Phone
        {
            get { return Wallpaper.Phone; }
            set
            {
                if (Wallpaper.Phone != value)
                {
                    Wallpaper.Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(Maker.Trim())) ||
                    (!string.IsNullOrEmpty(Price.ToString().Trim())) ||
                    (!string.IsNullOrEmpty(Date.ToString().Trim())) ||
                    (!string.IsNullOrEmpty(Email.Trim())) ||
                    (!string.IsNullOrEmpty(Phone.Trim())));
            }
        }





        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
