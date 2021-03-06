using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mPhoneApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://prjdelicious.azurewebsites.net/publicchat", new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
                
            }));
        }

        public ICommand OpenWebCommand { get; }
    }
}