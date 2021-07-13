
using mPhoneApp.Models;
using mPhoneApp.Views;
using mPhoneApp.web_address;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;

namespace mPhoneApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        private HttpClient _client = new HttpClient();
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {

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
                if (content == "account_no_found" || content == "empty") { await Shell.Current.GoToAsync($"//{nameof(LoginPage)}"); }
                else
                {
                    CMember_info creceipt = JsonConvert.DeserializeObject<CMember_info>(content);
                    App.cMember_Info.MemberId = creceipt.MemberId;
                    App.cMember_Info.Nickname = creceipt.Nickname;
                    App.cMember_Info.Password = password_before;
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
