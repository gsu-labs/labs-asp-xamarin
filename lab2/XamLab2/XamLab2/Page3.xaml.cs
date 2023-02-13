using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamLab2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        Label stackLabel;
        public Page3()
        {
            InitializeComponent();
            Button forwardButton = new Button
            {
                Text = "Вперед"
            };
            forwardButton.Clicked += GoToForward;

            stackLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            Content = new StackLayout { Children = { forwardButton, stackLabel } };
            Subscribe();
        }

        private void Subscribe()
        {
            MessagingCenter.Subscribe<Page>(
                this, // кто подписывается на сообщения
                "LabelChange",   // название сообщения
                (sender) => { stackLabel.Text = "Получено сообщение"; });    // вызываемое действие

        }

        private async void GoToForward(object sender, EventArgs e)
        {
            MessagePage page = new MessagePage();
            await Navigation.PushAsync(page);
        }
    }
}