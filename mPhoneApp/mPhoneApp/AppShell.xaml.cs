using mPhoneApp.ViewModels;
using mPhoneApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace mPhoneApp
{
    
    public partial class AppShell : Xamarin.Forms.Shell
    {
         
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(PublicChatPage), typeof(PublicChatPage));
            Routing.RegisterRoute(nameof(PageDetail), typeof(PageDetail));
            Routing.RegisterRoute(nameof(MallPage), typeof(MallPage));
            Routing.RegisterRoute(nameof(ShopCartPage), typeof(ShopCartPage));
            Routing.RegisterRoute(nameof(AddressPage), typeof(AddressPage));
            Routing.RegisterRoute(nameof(ShopResultPage), typeof(ShopResultPage));
            Routing.RegisterRoute(nameof(LogoutPage), typeof(LogoutPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
        
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
            if (App.cMember_Info.MemberId == 0)
            {
                await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
                logshow.Text = "登出";
            }
            else
            {
                App.cMember_Info.MemberId = 0;
                App.cMember_Info.AccountName = "";
                App.cMember_Info.Nickname = "匿名";
                App.cMember_Info.Password = "";
                logshow.Text = "登入";
                
                await Shell.Current.GoToAsync($"{nameof(LogoutPage)}");
                
            }
        }
        
    }
}
