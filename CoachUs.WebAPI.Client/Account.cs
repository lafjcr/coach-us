using CoachUs.WebAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace CoachUs.WebAPI.Client
{
    public static class Account
    {
        private const string hostUrlKey = "coachus-api";
        private const string apiTokenUrl = "Token";
        private const string apiUserInfoUrl = "Account/UserInfo";

        private static readonly string host;

        static Account()
        {
            host = ConfigurationManager.AppSettings[hostUrlKey];
        }

        public static string GetToken(string userName, string password)
        {
            using (var client = new HttpClient())
            {
                var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string> ("grant_type", "password"),
                        new KeyValuePair<string, string> ("username", userName),
                        new KeyValuePair<string, string> ("Password", password)
                    };
                var content = new FormUrlEncodedContent(pairs);

                // Attempt to get a token from the token endpoint of the Web Api host:
                var response = client.PostAsync(host + apiTokenUrl, content).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                // De-Serialize into a dictionary and return:
                var tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                return tokenDictionary["access_token"];
            }
        }

        public static UserInfoViewModel GetUserInfo(string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = client.GetAsync(host + apiUserInfoUrl).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<UserInfoViewModel>(result);
            }
        }
    }
}
