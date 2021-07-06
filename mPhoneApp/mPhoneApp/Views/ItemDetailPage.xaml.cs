using mPhoneApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace mPhoneApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}