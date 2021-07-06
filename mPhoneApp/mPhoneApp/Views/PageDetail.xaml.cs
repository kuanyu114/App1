using mPhoneApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class PageDetail : ContentPage
    {
        private int _ItemId = 0;
        public int ItemId
        {
            set
            {
                _ItemId = value;
            }
        }
        private HttpClient _client = new HttpClient();
        private ObservableCollection<CReceiptStep> _cReceiptStep;
        public PageDetail()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            var contents = await _client.GetStringAsync("https://webchart.azurewebsites.net/api/RecipeStep/?id="+_ItemId);
            var cReceiptStep = JsonConvert.DeserializeObject<List<CReceiptStep>>(contents);
            _cReceiptStep = new ObservableCollection<CReceiptStep>(cReceiptStep);
            list.ItemsSource = _cReceiptStep;
            base.OnAppearing();
        }
    }
}