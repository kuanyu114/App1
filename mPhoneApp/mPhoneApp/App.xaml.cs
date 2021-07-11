using mPhoneApp.Models;
using mPhoneApp.Services;
using mPhoneApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mPhoneApp
{
    public partial class App : Application
    {
        public static CMember_info cMember_Info = new CMember_info();
         
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
