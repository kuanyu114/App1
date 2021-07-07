using mPhoneApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class AddressPage : ContentPage
    {
        static COrder cOrder = new COrder();
        private HttpClient _client = new HttpClient();
        public AddressPage()
        {
            InitializeComponent();
        }
        private async void button_clicked(object sender, EventArgs e)
        {
            if (Reciever.Text == "" || PhoneNumber.Text == "" || DeliveryCounty.Text == "" || DeliveryDistrict.Text == "" || DeliveryAddress.Text == "")
            {
                return;
            }
            cOrder.memberId = 51;
            cOrder.reciever = Reciever.Text;
            cOrder.phoneNumber = PhoneNumber.Text;
            cOrder.deliveryCounty = DeliveryCounty.Text;
            cOrder.deliveryDistrict = DeliveryDistrict.Text;
            cOrder.deliveryAddress = DeliveryAddress.Text;

            var cshopitemslist = Cdatas.tempcart;

            Uri FooUrl = new Uri($"https://webchart.azurewebsites.net/api/AddDeliverInfo");
            Uri FooUrl1 = new Uri("https://webchart.azurewebsites.net/api/Addorder");
            HttpResponseMessage response = null;

             
             
            var fooJSON = JsonConvert.SerializeObject(cOrder);
            
            using (var fooContent = new StringContent(fooJSON, Encoding.UTF8, "application/json"))
            {
                response = await _client.PostAsync(FooUrl, fooContent);
            }
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"AddDeliverInfo successfully saved.");

                response = null;
                var fooJSON1 = JsonConvert.SerializeObject(cshopitemslist);
                using (var fooContent1 = new StringContent(fooJSON1, Encoding.UTF8, "application/json"))
                {
                    response = await _client.PostAsync(FooUrl1, fooContent1);
                }
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"Addorder successfully saved.");
                    Debug.WriteLine( response.Content.ToString());
                    await Browser.OpenAsync("https://prjdelicious.azurewebsites.net/OrderDetail/List?memberid=51&status=%E5%BE%85%E4%BB%98%E6%AC%BE", new BrowserLaunchOptions
                    {
                        LaunchMode = BrowserLaunchMode.SystemPreferred,
                        TitleMode = BrowserTitleMode.Show,
                        PreferredToolbarColor = Color.AliceBlue,
                        PreferredControlColor = Color.Violet

                    });
                
                }
                else
                {
                    Debug.WriteLine(response.StatusCode);
                }

            }
            else
            {
                Debug.WriteLine(response.StatusCode);
            }


        }
    }
}