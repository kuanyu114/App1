using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void button_to_aboutpage(object sender, EventArgs e)
        {
            var btn = sender as Button;
            
            
            await Shell.Current.GoToAsync(nameof(AboutPage));
            
        }
        private async void button_to_publicchat(object sender, EventArgs e)
        {
            var btn = sender as Button;


            await Shell.Current.GoToAsync(nameof(PublicChatPage));

        }
    }
}