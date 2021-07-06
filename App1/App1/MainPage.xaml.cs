using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static App1.MainPage;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        private HttpClient _client = new HttpClient();
        private ObservableCollection<CReceipt> _cReceipts;
        public MainPage()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            var contents = await _client.GetStringAsync("https://webchart.azurewebsites.net/api/RecipeList");
            var creceipt = JsonConvert.DeserializeObject<List<CReceipt>> (contents);
            _cReceipts = new ObservableCollection<CReceipt>(creceipt);
            list.ItemsSource = _cReceipts;
            base.OnAppearing();
        }

    }
}