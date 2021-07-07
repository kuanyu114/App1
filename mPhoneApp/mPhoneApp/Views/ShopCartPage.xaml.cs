using mPhoneApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [QueryProperty(nameof(cartQty), nameof(cartQty))]
    [QueryProperty(nameof(ingredient), nameof(ingredient))]
    [QueryProperty(nameof(unitprice), nameof(unitprice))]
    [QueryProperty(nameof(ingpicsrc), nameof(ingpicsrc))]
    public partial class ShopCartPage : ContentPage
    {
        private int _ItemId = 0;
        private int _cartQty = 0;
        private string _ingredient = "";
        private string _unitprice = "";
        private string _ingpicsrc="";
        public int ItemId
        {
            set
            {
                _ItemId = value;
            }
        }
        public int cartQty
        {
            set
            {
                _cartQty = value;
            }
        }
        public string ingredient
        {
            set
            {
                _ingredient = value;
            }
        }
        public string unitprice
        {
            set
            {
                _unitprice = value;
            }
        }
        public string ingpicsrc
        {
            set
            {
                _ingpicsrc = value;
            }
        }
        
        private HttpClient _client = new HttpClient();       
        public ShopCartPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            bool setnewitem = false;
            if (Cdatas.tempcart.Count == 0)
            {
                setnewitem = true;
            }
            else
            {
                foreach (var item in Cdatas.tempcart)
                {
                    if (item.ingid == _ItemId)
                    {
                        item.cartQty++;
                        setnewitem = false;
                        break;
                    }
                    else
                    {
                        setnewitem = true;
                    }
                }
            }
            if (setnewitem)
            {
                CShopCart cShopCart = new CShopCart();
                cShopCart.cartQty = _cartQty;
                cShopCart.ingid = _ItemId;
                cShopCart.ingredient = _ingredient;
                cShopCart.unitprice = _unitprice;
                cShopCart.ingpicsrc = _ingpicsrc;
                Cdatas.tempcart.Add(cShopCart);
            }
            list.ItemsSource = Cdatas.tempcart;
            base.OnAppearing();
        }
        private async void button_clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(AddressPage)}");
            //var btn = sender as Button;
           
        }
    }
}