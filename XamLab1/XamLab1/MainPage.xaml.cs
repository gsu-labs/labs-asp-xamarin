using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamLab1
{
    public partial class MainPage : ContentPage
    {
        View mainPage;
        List<Souvenir> souvenirs;
        public MainPage()
        {
            InitializeComponent();
            mainPage = this.Content;
            souvenirs = new List<Souvenir>();
            Souvenir souvenir1 = new Souvenir()
            {
                Name = "Брелок",
                Maker = "ABC",
                Price = 1000,
                Date = Convert.ToDateTime("20.10.2020")
            };
            Souvenir souvenir2 = new Souvenir()
            {
                Name = "Майка",
                Maker = "Vsemayki",
                Price = 4000,
                Date = Convert.ToDateTime("11.03.2019")
            };
            Souvenir souvenir3 = new Souvenir()
            {
                Name = "Флажок",
                Maker = "Yewa",
                Price = 400,
                Date = Convert.ToDateTime("15.07.2020")
            };
            souvenirs.Add(souvenir1);
            souvenirs.Add(souvenir2);
            souvenirs.Add(souvenir3);
            picker1.Items.Add(souvenir1.Name);
            picker1.Items.Add(souvenir2.Name);
            picker1.Items.Add(souvenir3.Name);

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
                    new TableSection("Информация о сувенире")
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
                picker1.Items.Add(new Souvenir() { Name = "Новый сувенир" }.Name);
                setMainPage();
            }
        }

        private void OnButtonBackClicked(object sender, EventArgs e)
        {
            setMainPage();
        }

        private void setMainPage()
        {
            //this.Content = null;
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


        private void SelectedSouvenir(object sender, EventArgs e)
        {
            if (stackLayout1.Children.Count > 5)
            {
                stackLayout1.Children.RemoveAt(4);
                stackLayout1.Children.RemoveAt(4);
            }

            Souvenir souvenir = souvenirs[picker1.SelectedIndex];

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
                            Detail = souvenir.Name
                            

                        },
                        new TextCell
                        {
                            Text = "Производитель:",
                            Detail = souvenir.Maker

                        },
                        new TextCell
                        {
                            Text = "Цена:",
                            Detail = souvenir.Price.ToString()

                        },
                        new TextCell
                        {
                            Text = "Дата продажи:",
                            Detail = Convert.ToDateTime(souvenir.Date).ToShortDateString()
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
