using mPhoneApp.Models;
using mPhoneApp.web_address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopResultPage : ContentPage
    {
        public ShopResultPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Browser.OpenAsync(COutSideWebAddress.projectWebAddress + "OrderDetail/List?memberid="+App.cMember_Info.MemberId+"&status=%E5%BE%85%E4%BB%98%E6%AC%BE", new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet

            });
            Cdatas.tempcart = new List<CShopCart>();

        }
        private async void button_clicked(object sender, EventArgs e)
        {
            
            await Shell.Current.GoToAsync("///MallPage");
        }
    }
}