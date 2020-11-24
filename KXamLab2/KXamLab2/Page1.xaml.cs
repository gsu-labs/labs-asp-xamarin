using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KXamLab2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public static ObservableCollection<Wallpaper> Wallpapers { get; set; }
        ListView listView;
        StackLayout page1;
        StackLayout stackLayoutSavePage;
        string imgPath;
        public Page1()
        {
            InitializeComponent();
            object name = "";
            if (App.Current.Properties.TryGetValue("1", out name))
            {
                Wallpapers = JsonConvert.DeserializeObject<ObservableCollection<Wallpaper>>(name.ToString());
            }
            else
            {
                Wallpapers = new ObservableCollection<Wallpaper>
                {
                new Wallpaper{ Name = "Белобои Кирпичики", Maker = "Минская обойная фабрика", Price = 45, Date = Convert.ToDateTime("11.04.2019"), ImagePath="white"},
                new Wallpaper{ Name = "Белобои Лаванда", Maker = "Волсти", Price = 23, Date = Convert.ToDateTime("19.07.2020"), ImagePath="lavanda"},
                new Wallpaper{ Name = "Батик", Maker = "Гомельобои", Price = 50, Date = Convert.ToDateTime("15.07.2020"), ImagePath="batik"},
                new Wallpaper{ Name = "Принты", Maker = "Клерен", Price = 76, Date =  Convert.ToDateTime("03.09.2021"), ImagePath="print" }
                };
            }

            Label header = new Label
            {
                Text = "Список обоев",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = Wallpapers,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    Binding souvenirBinding = new Binding { Path = "Maker", StringFormat = "Обои от производителя {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, souvenirBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "ImagePath");
                    return imageCell;
                })
            };

            Button buttonAdd = new Button();
            buttonAdd.Text = "Добавить";
            buttonAdd.Clicked += AddItem;

            Button buttonDelete = new Button();
            buttonDelete.Text = "Удалить";
            buttonDelete.Clicked += DeleteItem;
            page1 = new StackLayout { Children = { header, listView, buttonAdd, buttonDelete } };
            this.Content = page1;
        }

        private async void DeleteItem(object sender, EventArgs e)
        {
            Wallpaper selectedWallpaper = (Wallpaper)listView.SelectedItem;
            if (selectedWallpaper == null)
            {
                await DisplayAlert("Предупреждение", "Выберите одни из обоев", "Ок");
            }
            else
            {
                bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить элемент?", "Да", "Нет");
                if (result)
                {
                    Wallpapers.Remove(selectedWallpaper);
                    SaveDates();
                }
            }
        }

        private async void SaveDates()
        {
            string jsonStr = JsonConvert.SerializeObject(Wallpapers);
            App.Current.Properties["1"] = jsonStr;
            await App.Current.SavePropertiesAsync();
        }

        private void AddItem(object sender, EventArgs e)
        {

            stackLayoutSavePage = new StackLayout();
            Label label1 = new Label();
            label1.Text = "Название";
            Entry entry1 = new Entry();

            Label label2 = new Label();
            label2.Text = "Производетель";
            Entry entry2 = new Entry();

            Label label3 = new Label();
            label3.Text = "Цена";
            Entry entry3 = new Entry();
            entry3.Keyboard = Keyboard.Numeric;



            Label label4 = new Label();
            label4.Text = "Дата продажи";

            DatePicker datePicker1 = new DatePicker()
            {
                Format = "D",
            };

            Button buttonSave = new Button();
            buttonSave.Text = "Сохранить";
            buttonSave.Clicked += ButtonSave_Clicked;

            Button buttonBack = new Button();
            buttonBack.Text = "Назад";
            buttonBack.Clicked += ButtonBack_Clicked;


            Button getPhotoBtn = new Button { Text = "Выбрать фото" };
            Image img = new Image();
            img.IsVisible = false;



            getPhotoBtn.Clicked += async (o, l) =>
            {
                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                    imgPath = photo.Path;
                }
            };

            stackLayoutSavePage.Children.Add(label1);
            stackLayoutSavePage.Children.Add(entry1);

            stackLayoutSavePage.Children.Add(label2);
            stackLayoutSavePage.Children.Add(entry2);

            stackLayoutSavePage.Children.Add(label3);
            stackLayoutSavePage.Children.Add(entry3);

            stackLayoutSavePage.Children.Add(label4);
            stackLayoutSavePage.Children.Add(datePicker1);

            stackLayoutSavePage.Children.Add(img);

            stackLayoutSavePage.Children.Add(getPhotoBtn);
            stackLayoutSavePage.Children.Add(buttonSave);
            stackLayoutSavePage.Children.Add(buttonBack);

            stackLayoutSavePage.Padding = 5;
            this.Content = stackLayoutSavePage;

        }

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            Entry entry1 = (Entry)stackLayoutSavePage.Children[1];
            Entry entry3 = (Entry)stackLayoutSavePage.Children[3];
            Entry entry5 = (Entry)stackLayoutSavePage.Children[5];
            DatePicker datePicker1 = (DatePicker)stackLayoutSavePage.Children[7];

            Wallpapers.Add(new Wallpaper { Name = entry1.Text, Maker = entry3.Text, Price = Convert.ToInt32(entry5.Text), Date = Convert.ToDateTime(datePicker1.Date), ImagePath = imgPath });
            SaveDates();
            this.Content = page1;
        }

        private void ButtonBack_Clicked(object sender, EventArgs e)
        {
            this.Content = page1;
        }
    }
}