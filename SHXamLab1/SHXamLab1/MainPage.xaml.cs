using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SHXamLab1
{
    public partial class MainPage : ContentPage
    {
        View mainPage;
        List<Movie> movies;
        public MainPage()
        {
            InitializeComponent();
            mainPage = this.Content;
            movies = new List<Movie>();
            Movie movie1 = new Movie()
            {
                Name = "Довод",
                Genre = "Фантастика",
                Price = 50,
                Date = Convert.ToDateTime("12.08.2020")
            };
            Movie movie2 = new Movie()
            {
                Name = "Дэдпул",
                Genre = "Боевик",
                Price = 45,
                Date = Convert.ToDateTime("10.02.2016")
            };
            Movie movie3 = new Movie()
            {
                Name = "Зеленая миля",
                Genre = "Драма",
                Price = 43,
                Date = Convert.ToDateTime("06.12.1999")
            };
            movies.Add(movie1);
            movies.Add(movie2);
            movies.Add(movie3);
            picker1.Items.Add(movie1.Name);
            picker1.Items.Add(movie2.Name);
            picker1.Items.Add(movie3.Name);

            picker1.SelectedIndexChanged += SelectedSouvenir;
            buttondAdd.Clicked += OnButtonAddClicked;
        }

        private void OnButtonAddClicked(object sender, EventArgs e)
        {
            StackLayout stackLayout = new StackLayout();
            DatePicker datePicker = new DatePicker()
            {
                Format = "D",
            };

            Label label = new Label();
            label.Text = "Введите дату:";
            label.Margin = 13;

            StackLayout stackLayout1 = new StackLayout();
            stackLayout1.Orientation = StackOrientation.Horizontal;

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Ввод данных")
                {
                    new TableSection("Информация о фильме")
                    {
                        new EntryCell
                        {
                            Label = "Название",
                            Placeholder = "Введите название",
                            Keyboard = Keyboard.Text
                        },
                        new EntryCell
                        {
                            Label = "Жанр",
                            Placeholder = "Введите жанр",
                            Keyboard = Keyboard.Text
                        },
                        new EntryCell
                        {
                            Label = "Цена",
                            Placeholder = "Введите цену",
                            Keyboard = Keyboard.Numeric
                        },
                        new ViewCell
                        {
                            View = stackLayout1
                        }
                    }
                }
            };


            Button buttonSave = new Button();
            buttonSave.Text = "Сохранить";
            buttonSave.Clicked += OnButtonSaveClicked;

            Button buttonBack = new Button();
            buttonBack.Text = "Назад";
            buttonBack.Clicked += OnButtonBackClicked;

            stackLayout1.Children.Add(label);
            stackLayout1.Children.Add(datePicker);
            stackLayout.Children.Add(tableView);
            stackLayout.Children.Add(buttonSave);
            stackLayout.Children.Add(buttonBack);
            this.Content = stackLayout;
        }

        private async void OnButtonSaveClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Предупреждение", "Вы точно хотите сохранить", "Да", "Нет");
            if (result)
            {
                picker1.Items.Add(new Movie() { Name = "Новый фильм" }.Name);
                setMainPage();
            }
        }

        private void OnButtonBackClicked(object sender, EventArgs e)
        {
            setMainPage();
        }

        private void setMainPage()
        {
            this.Content = mainPage;
        }

        private void OnButtonBackFromMainClicked(object sender, EventArgs e)
        {
            if (stackLayout1.Children.Count > 5)
            {
                stackLayout1.Children.RemoveAt(4);
                stackLayout1.Children.RemoveAt(4);
            }
        }


        private void SelectedMovie(object sender, EventArgs e)
        {
            if (stackLayout1.Children.Count > 5)
            {
                stackLayout1.Children.RemoveAt(4);
                stackLayout1.Children.RemoveAt(4);
            }

            Movie movie = movies[picker1.SelectedIndex];

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot()
                {
                    new TableSection("Информация о сувенире")
                    {
                        new TextCell
                        {

                            Text = "Название:",
                            Detail = movie.Name


                        },
                        new TextCell
                        {
                            Text = "Жанр:",
                            Detail = movie.Genre

                        },
                        new TextCell
                        {
                            Text = "Цена:",
                            Detail = movie.Price.ToString()

                        },
                        new TextCell
                        {
                            Text = "Дата выхода:",
                            Detail = Convert.ToDateTime(movie.Date).ToShortDateString()
                        }
                    }
                }
            };

            Button buttonBack = new Button();
            buttonBack.Text = "Назад";
            buttonBack.Clicked += OnButtonBackFromMainClicked;
            stackLayout1.Children.Add(tableView);
            stackLayout1.Children.Add(buttonBack);
        }
    }
}
