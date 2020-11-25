using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KXamLab1
{
    public partial class MainPage : ContentPage
    {
        View mainPage;
        List<Wallpaper> wallpapers;
        public MainPage()
        {
            InitializeComponent();
            mainPage = this.Content;
            wallpapers = new List<Wallpaper>();
            Wallpaper wallpaper1 = new Wallpaper()
            {
                Name = "Белобои Кирпичики",
                Maker = "Минская обойная фабрика",
                Price = 45,
                Date = Convert.ToDateTime("11.04.2019")
            };
            Wallpaper wallpaper2 = new Wallpaper()
            {
                Name = "Белобои Лаванда",
                Maker = "Волсти",
                Price = 23,
                Date = Convert.ToDateTime("19.07.2020")
            };
            Wallpaper wallpaper3 = new Wallpaper()
            {
                Name = "Батик",
                Maker = "Гомельобои",
                Price = 50,
                Date = Convert.ToDateTime("15.07.2020")
            };
            wallpapers.Add(wallpaper1);
            wallpapers.Add(wallpaper2);
            wallpapers.Add(wallpaper3);
            picker1.Items.Add(wallpaper1.Name);
            picker1.Items.Add(wallpaper2.Name);
            picker1.Items.Add(wallpaper3.Name);

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
                    new TableSection("Информация о обоях")
                    {
                        new EntryCell
                        {
                            Label = "Название",
                            Placeholder = "Введите название",
                            Keyboard = Keyboard.Text
                        },
                        new EntryCell
                        {
                            Label = "Производитель",
                            Placeholder = "Введите производителя",
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
                picker1.Items.Add(new Wallpaper() { Name = "Новые обои" }.Name);
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


        private void SelectedWallpaper(object sender, EventArgs e)
        {
            if (stackLayout1.Children.Count > 5)
            {
                stackLayout1.Children.RemoveAt(4);
                stackLayout1.Children.RemoveAt(4);
            }

            Wallpaper wallpaper = wallpapers[picker1.SelectedIndex];

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot()
                {
                    new TableSection("Информация о обоях")
                    {
                        new TextCell
                        {

                            Text = "Название:",
                            Detail = wallpaper.Name


                        },
                        new TextCell
                        {
                            Text = "Производитель:",
                            Detail = wallpaper.Maker

                        },
                        new TextCell
                        {
                            Text = "Цена:",
                            Detail = wallpaper.Price.ToString()

                        },
                        new TextCell
                        {
                            Text = "Дата продажи:",
                            Detail = Convert.ToDateTime(wallpaper.Date).ToShortDateString()
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
