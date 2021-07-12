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

            if (!double.TryParse(EntryLatitude.Text, out double lat))
                return;
            if (!double.TryParse(EntryLongitude.Text, out double lng))
                return;
            await Map.OpenAsync(lat, lng, new MapLaunchOptions {
                Name = EntryName.Text,
               NavigationMode = NavigationMode.None
            });
        }
    }
    public class MapTest
    {
        public async Task NavigateToBuilding25()
        {
            var location = new Location(47.645160, -122.1306032);
            var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                // No map application available to open
            }
        }
    }

}