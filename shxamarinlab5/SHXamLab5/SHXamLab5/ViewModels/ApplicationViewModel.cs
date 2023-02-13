using SHXamLab5.Models;
using SHXamLab5.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SHXamLab5.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;
        Movie selectedMovie;
        private bool isBusy;

        public ObservableCollection<Movie> Movies { get; set; }
        MovieService movieService = new MovieService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateMovieCommand { protected set; get; }
        public ICommand DeleteMovieCommand { protected set; get; }
        public ICommand SaveMovieCommand { protected set; get; }
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
            Movies = new ObservableCollection<Movie>();
            IsBusy = false;
            CreateMovieCommand = new Command(CreateMovie);
            DeleteMovieCommand = new Command(DeleteMovie);
            SaveMovieCommand = new Command(SaveMovie);
            BackCommand = new Command(Back);
        }

        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                if (selectedMovie != value)
                {
                    Movie tempMovie = new Movie()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Genre = value.Genre,
                        Price = value.Price,
                        Date = value.Date,
                        Email = value.Email,
                        Phone = value.Phone
                    };
                    selectedMovie = null;
                    OnPropertyChanged("SelectedMovie");
                    Navigation.PushAsync(new MoviePage(tempMovie, this));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateMovie()
        {
            await Navigation.PushAsync(new MoviePage(new Movie(), this));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }

        public async Task GetMovies()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Movie> movies = await movieService.Get();

            while (Movies.Any())
                Movies.RemoveAt(Movies.Count - 1);

            // добавляем загруженные данные
            foreach (Movie s in movies)
                Movies.Add(s);
            IsBusy = false;
            initialized = true;
        }
        private async void SaveMovie(object movieObject)
        {
            Movie movie = movieObject as Movie;
            if (movie != null)
            {
                IsBusy = true;
                if (movie.Id > 0)
                {
                    Movie updatedMovie = await movieService.Update(movie);
                    if (updatedMovie != null)
                    {
                        int pos = Movies.IndexOf(updatedMovie);
                        Movies.RemoveAt(pos);
                        Movies.Insert(pos, updatedMovie);
                    }
                }
                else
                {
                    Movie addedMovie = await movieService.Add(movie);
                    if (addedMovie != null)
                        Movies.Add(addedMovie);
                }
                IsBusy = false;
            }
            Back();
        }
        private async void DeleteMovie(object movieObject)
        {
            Movie movie = movieObject as Movie;
            if (movie != null)
            {
                IsBusy = true;
                Movie deletedMovie = await movieService.Delete(movie.Id);
                if (deletedMovie != null)
                {
                    Movies.Remove(deletedMovie);
                }
                IsBusy = false;
            }
            Back();
        }
    }
}
