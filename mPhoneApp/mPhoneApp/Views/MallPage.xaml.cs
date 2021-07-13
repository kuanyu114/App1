using mPhoneApp.Models;
using mPhoneApp.web_address;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MallPage : ContentPage
    {
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Cshopitemslist> _cshopitemslist;
        public MallPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            var contents = await _client.GetStringAsync(COutSideWebAddress.projectWebAddress + "apiphone/shopitemlist");
            var cshopitemslist = JsonConvert.DeserializeObject<List<Cshopitemslist>>(contents);
            _cshopitemslist = new ObservableCollection<Cshopitemslist>(cshopitemslist);
            list.ItemsSource = _cshopitemslist;
            base.OnAppearing();
        }
        private async void button_clicked(object sender, EventArgs e)
        {
            
            var btn = sender as Button;
            var cshopitemslist = btn.CommandParameter as Cshopitemslist;           
            await Shell.Current.GoToAsync($"{nameof(ShopCartPage)}?{nameof(ShopCartPage.ItemId)}={cshopitemslist.IngredientId}" +
                $"&{nameof(ShopCartPage.cartQty)}={1}" +
                $"&{nameof(ShopCartPage.ingredient)}={cshopitemslist.Ingredient}" +
                $"&{nameof(ShopCartPage.unitprice)}={ cshopitemslist.Price }" +
                $"&{nameof(ShopCartPage.ingpicsrc)}={ cshopitemslist.MerchandisePicture }");
        }
    }
}