using mPhoneApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Threading.Tasks;
using mPhoneApp.web_address;

namespace mPhoneApp.Views
{
    public partial class AboutPage : ContentPage
    {
        private HttpClient _client = new HttpClient();
        private ObservableCollection<CReceipt> _cReceipts;
        public AboutPage()
        {
            InitializeComponent();
          
        }
        protected override async void OnAppearing()
        {
            var contents = await _client.GetStringAsync(COutSideWebAddress.projectWebAddress + "apiphone/RecipeList");
            var creceipt = JsonConvert.DeserializeObject<List<CReceipt>>(contents);
            _cReceipts = new ObservableCollection<CReceipt>(creceipt);
            list.ItemsSource = _cReceipts;
            base.OnAppearing();
        }
        private async void  button_clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var creceipt = btn.CommandParameter as CReceipt;
            //this.Navigation.PushAsync(new NewItemPage());
            //await Shell.Current.GoToAsync(nameof(PageDetail));
            await Shell.Current.GoToAsync($"{nameof(PageDetail)}?{nameof(PageDetail.ItemId)}={creceipt.recipeId}");
        }
    }
}