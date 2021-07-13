using mPhoneApp.Models;
using mPhoneApp.ViewModels;
using mPhoneApp.web_address;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private HttpClient _client = new HttpClient();
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Command="{Binding LoginCommand}"   
            string password = App.cMember_Info.Password;
            for (int i = 0; i < 100; i++)
            {
                password = ConvertToSha256(password);
            }
            string password_before = App.cMember_Info.Password;
            App.cMember_Info.Password = password;
            Uri FooUrl = new Uri(COutSideWebAddress.projectWebAddress + "Apiphone/member_account_check");
            HttpResponseMessage response = null;

            var fooJSON = JsonConvert.SerializeObject(App.cMember_Info);

            using (var fooContent = new StringContent(fooJSON, Encoding.UTF8, "application/json"))
            {
                response = await _client.PostAsync(FooUrl, fooContent);
            }
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                if (content == "account_no_found" || content == "empty")
                {
                    await DisplayAlert("提示","帳號/密碼錯誤", "OK");
                    return; /*await Shell.Current.GoToAsync($"{nameof(LoginPage)}");*/
                }
                else
                {
                    CMember_info creceipt = JsonConvert.DeserializeObject<CMember_info>(content);
                    App.cMember_Info.MemberId = creceipt.MemberId;
                    App.cMember_Info.Nickname = creceipt.Nickname;
                    App.cMember_Info.Password = password_before;
                    Member_Account.Text = "";
                    Member_Password.Text = "";
                    await DisplayAlert("歡迎", creceipt.Nickname + "歡迎回來", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                    //await Shell.Current.GoToAsync($"../../MainPage");
                }
            }
        }
        public static string ConvertToSha256(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = SHA256Managed.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }
    }
}