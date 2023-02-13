using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SXamLab1
{
    public partial class MainPage : ContentPage
    {
        View mainPage;
        List<Garden> gardens;
        public MainPage()
        {
            InitializeComponent();
            mainPage = this.Content;
            gardens = new List<Garden>();
            Garden garden1 = new Garden()
            {
                Name = "Одноколёсная тачка",
                Maker = "Альфасто",
                Price = 86,
                Date = Convert.ToDateTime("07.12.2019")
            };
            Garden garden2 = new Garden()
            {
                Name = "Лопата штыковая",
                Maker = "STARTUL",
                Price = 40,
                Date = Convert.ToDateTime("03.04.2020")
            };
            Garden garden3 = new Garden()
            {
                Name = "Грабли веерные",
                Maker = "Fiskars",
                Price = 20,
                Date = Convert.ToDateTime("16.04.2020")
            };
            gardens.Add(garden1);
            gardens.Add(garden2);
            gardens.Add(garden3);
            picker1.Items.Add(garden1.Name);
            picker1.Items.Add(garden2.Name);
            picker1.Items.Add(garden3.Name);

            picker1.SelectedIndexChanged += SelectedGarden;
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
                    new TableSection("Информация о предмете")
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
                picker1.Items.Add(new Garden() { Name = "Новый предмет" }.Name);
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


        private void SelectedGarden(object sender, EventArgs e)
        {
            if (stackLayout1.Children.Count > 5)
            {
                stackLayout1.Children.RemoveAt(4);
                stackLayout1.Children.RemoveAt(4);
            }

            Garden garden = gardens[picker1.SelectedIndex];

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
                            Detail = garden.Name


                        },
                        new TextCell
                        {
                            Text = "Производитель:",
                            Detail = garden.Maker

                        },
                        new TextCell
                        {
                            Text = "Цена:",
                            Detail = garden.Price.ToString()

                        },
                        new TextCell
                        {
                            Text = "Дата продажи:",
                            Detail = Convert.ToDateTime(garden.Date).ToShortDateString()
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
