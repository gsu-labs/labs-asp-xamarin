using SXamLab3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;

namespace SXamLab3.ViewModels
{
    public class GardenViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        GardensListViewModel lvm;
        public Garden Garden { get; private set; }
        public GardenViewModel()
        {
            Garden = new Garden();
        }

        public GardensListViewModel ListViewModel
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
            get { return Garden.Name; }
            set
            {
                if (Garden.Name != value)
                {
                    Garden.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Maker
        {
            get { return Garden.Maker; }
            set
            {
                if (Garden.Maker != value)
                {
                    Garden.Maker = value;
                    OnPropertyChanged("Maker");
                }
            }
        }

        public int Price
        {
            get { return Garden.Price; }
            set
            {
                if (Garden.Price != value)
                {
                    Garden.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public DateTime Date
        {
            get { return Garden.Date; }
            set
            {
                if (Garden.Date != value)
                {
                    Garden.Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string Email
        {
            get { return Garden.Email; }
            set
            {
                if (Garden.Email != value)
                {
                    try
                    {
                        var mail = new MailAddress(value);
                        Garden.Email = mail.ToString();
                        OnPropertyChanged("Email");
                    }
                    catch
                    {
                        Garden.Email = value + "@mail.ru";
                    }
                }
            }
        }
        public string Phone
        {
            get { return Garden.Phone; }
            set
            {
                if (Garden.Phone != value)
                {
                    Garden.Phone = value;
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
