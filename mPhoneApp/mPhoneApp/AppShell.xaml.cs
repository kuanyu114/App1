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
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(PublicChatPage), typeof(PublicChatPage));
            Routing.RegisterRoute(nameof(PageDetail), typeof(PageDetail));
            Routing.RegisterRoute(nameof(MallPage), typeof(MallPage));
            Routing.RegisterRoute(nameof(ShopCartPage), typeof(ShopCartPage));
            Routing.RegisterRoute(nameof(AddressPage), typeof(AddressPage));
            
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
