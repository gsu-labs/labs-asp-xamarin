using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHXamLab2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        public MessagePage()
        {
            InitializeComponent();
            Title = "MessagePage";
            Button backBtn = new Button
            {
                Text = "Назад"
            };
            backBtn.Clicked += GoToBack;

            Content = new StackLayout { Children = { backBtn } };
        }

        private async void GoToBack(object sender, EventArgs e)
        {
            MessagingCenter.Send<Page>(this, "LabelChange");
            await Navigation.PopAsync();
        }
    }
}