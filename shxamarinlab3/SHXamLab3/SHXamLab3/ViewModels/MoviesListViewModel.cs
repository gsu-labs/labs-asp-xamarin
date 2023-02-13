using SHXamLab3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SHXamLab3.ViewModels
{
    public class MoviesListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MovieViewModel> Movies { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateMovieCommand { protected set; get; }
        public ICommand DeleteMovieCommand { protected set; get; }
        public ICommand SaveMovieCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public ICommand MoveToTopCommand { protected set; get; }
        public ICommand MoveToBottomCommand { protected set; get; }
        public ICommand RemoveCommand { protected set; get; }

        MovieViewModel selectedMovie;
        public INavigation Navigation { get; set; }
        public MoviesListViewModel()
        {
            Movies = new ObservableCollection<MovieViewModel>()
            {
                new MovieViewModel{ Name = "Довод", Genre = "Фантастика", Price = 50, Date = Convert.ToDateTime("12.08.2020"), Email="sfa@mail.ru", Phone="375295341276", ListViewModel = this},
                new MovieViewModel{ Name = "Дэдпул шар", Genre = "Боевик", Price = 45, Date = Convert.ToDateTime("10.02.2016"), Email="gfgf@gmail.com", Phone="375446427812", ListViewModel = this},
                new MovieViewModel{ Name = "Зеленая миля", Genre = "Драма", Price = 43, Date = Convert.ToDateTime("06.12.1999"), Email="qwfasf@gmail.com", Phone="375359741204", ListViewModel = this},
                new MovieViewModel{ Name = "Мстители: финал", Genre = "Боевик", Price = 60, Date =  Convert.ToDateTime("25.04.2019"), Email="dgwdaa@mail.ru", Phone="375440781252", ListViewModel = this }
            };
            CreateMovieCommand = new Command(CreateMovie);
            DeleteMovieCommand = new Command(DeleteMovie);
            SaveMovieCommand = new Command(SaveMovie);
            BackCommand = new Command(Back);


            MoveToTopCommand = new Command(MoveToTop);
            MoveToBottomCommand = new Command(MoveToBottom);
            RemoveCommand = new Command(Remove);
        }

        public MovieViewModel SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                if (selectedMovie != value)
                {
                    MovieViewModel tempMovie = value;
                    selectedMovie = null;
                    OnPropertyChanged("SelectedMovie");
                    Navigation.PushAsync(new MoviePage(tempMovie));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateMovie()
        {
            Navigation.PushAsync(new MoviePage(new MovieViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveMovie(object movieObject)
        {
            MovieViewModel movie = movieObject as MovieViewModel;
            if (movie != null && movie.IsValid)
            {
                Movies.Add(movie);
            }
            Back();
        }
        private void DeleteMovie(object movieObject)
        {
            MovieViewModel movie = movieObject as MovieViewModel;
            if (movie != null)
            {
                Movies.Remove(movie);
            }
            Back();
        }


        private void MoveToTop(object movieObject)
        {
            MovieViewModel movie = movieObject as MovieViewModel;
            if (movie == null) return;
            int oldIndex = Movies.IndexOf(movie);
            if (oldIndex > 0)
                Movies.Move(oldIndex, oldIndex - 1);
        }
        private void MoveToBottom(object movieObj)
        {
            MovieViewModel movie = movieObj as MovieViewModel;
            if (movie == null) return;
            int oldIndex = Movies.IndexOf(movie);
            if (oldIndex < Movies.Count - 1)
                Movies.Move(oldIndex, oldIndex + 1);
        }
        private void Remove(object movieObj)
        {
            MovieViewModel movie = movieObj as MovieViewModel;
            if (movie == null) return;

            Movies.Remove(movie);
        }
    }
}
