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
    public partial class MapSearchPage : ContentPage
    {
        public MapSearchPage()
        {
            InitializeComponent();
        }

        private async void buttonopen_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty( EntryName.Text) )
            {
                var address = EntryName.Text;
                var locations = await Geocoding.GetLocationsAsync(address);

                var location = locations?.FirstOrDefault();

                await Map.OpenAsync(location, new MapLaunchOptions
                {
                    Name = EntryName.Text,
                    NavigationMode = NavigationMode.None
                });
            }
            else
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
                //if (!double.TryParse(EntryLatitude.Text, out double lat))
                //    return;
                //if (!double.TryParse(EntryLongitude.Text, out double lng))
                //    return;
                //await Map.OpenAsync(lat, lng, new MapLaunchOptions {
                //    Name = EntryName.Text,
                //   NavigationMode = NavigationMode.None
                //});
                await Map.OpenAsync(location, new MapLaunchOptions
                {
                    Name = "您的所在地",
                    NavigationMode = NavigationMode.None
                });
            }
        }
    }
   

}