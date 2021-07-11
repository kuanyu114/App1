using mPhoneApp.Models;
using mPhoneApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            
        }
         
        private void Member_Account_Completed(object sender, EventArgs e)
        {
            App.cMember_Info.AccountName = Member_Account.Text.ToString();
        }

        private void Member_Password_Completed(object sender, EventArgs e)
        {
            App.cMember_Info.Password = Member_Password.Text.ToString();
        }
    }
}