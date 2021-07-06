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
            Title = "公開聊天室";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://webchart.azurewebsites.net/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}