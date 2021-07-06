using App2.ViewModels;
using System;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App2.Views
{

    public partial class AboutPage : ContentPage
    {
        private HttpClient _client = new HttpClient();
        private ObservableCollection<CReceipt> _cReceipts;
        public AboutPage()
        {
            InitializeComponent();
          
           

        }

    }
}

