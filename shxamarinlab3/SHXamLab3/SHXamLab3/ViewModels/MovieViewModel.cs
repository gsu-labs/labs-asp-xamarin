using SHXamLab3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;

namespace SHXamLab3.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        MoviesListViewModel lvm;
        public Movie Movie { get; private set; }
        public MovieViewModel()
        {
            Movie = new Movie();
        }

        public MoviesListViewModel ListViewModel
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
            get { return Movie.Name; }
            set
            {
                if (Movie.Name != value)
                {
                    Movie.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Genre
        {
            get { return Movie.Genre; }
            set
            {
                if (Movie.Genre != value)
                {
                    Movie.Genre = value;
                    OnPropertyChanged("Genre");
                }
            }
        }

        public int Price
        {
            get { return Movie.Price; }
            set
            {
                if (Movie.Price != value)
                {
                    Movie.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public DateTime Date
        {
            get { return Movie.Date; }
            set
            {
                if (Movie.Date != value)
                {
                    Movie.Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string Email
        {
            get { return Movie.Email; }
            set
            {
                if (Movie.Email != value)
                {
                    try
                    {
                        var mail = new MailAddress(value);
                        Movie.Email = mail.ToString();
                        OnPropertyChanged("Email");
                    }
                    catch
                    {
                        Movie.Email = value + "@mail.ru";
                    }
                }
            }
        }
        public string Phone
        {
            get { return Movie.Phone; }
            set
            {
                if (Movie.Phone != value)
                {
                    Movie.Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(Genre.Trim())) ||
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
