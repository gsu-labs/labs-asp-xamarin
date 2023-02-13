using MVVMXamLab3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MVVMXamLab3.ViewModels
{
    public class SouvenirViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        SouvenirsListViewModel lvm;
        public Souvenir Souvenir { get; private set; }
        public SouvenirViewModel()
        {
            Souvenir = new Souvenir();
        }

        public SouvenirsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if(lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return Souvenir.Name; }
            set
            {
                if(Souvenir.Name != value)
                {
                    Souvenir.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Maker
        {
            get { return Souvenir.Maker; }
            set
            {
                if (Souvenir.Maker != value)
                {
                    Souvenir.Maker = value;
                    OnPropertyChanged("Maker");
                }
            }
        }

        public int Price
        {
            get { return Souvenir.Price; }
            set
            {
                if (Souvenir.Price != value)
                {
                    Souvenir.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public DateTime Date
        {
            get { return Souvenir.Date; }
            set
            {
                if (Souvenir.Date != value)
                {
                    Souvenir.Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string Email
        {
            get { return Souvenir.Email; }
            set
            {
                if (Souvenir.Email != value)
                {
                    try
                    {
                        var mail = new MailAddress(value);
                        Souvenir.Email = mail.ToString();
                        OnPropertyChanged("Email");
                    }
                    catch 
                    {
                        Souvenir.Email = value + "@mail.ru";
                    }
                }
            }
        }
        public string Phone
        {
            get { return Souvenir.Phone; }
            set
            {
                if (Souvenir.Phone != value)
                {
                    Souvenir.Phone = value;
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
