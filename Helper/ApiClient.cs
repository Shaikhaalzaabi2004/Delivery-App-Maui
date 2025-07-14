using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Helper
{
    public class ApiClient
    {
         public HttpClient httpClient = new HttpClient();
        public ApiClient() {
            httpClient = new HttpClient();

            string username = "staff";
            string password = "password";

            var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", encodedCredentials);
        }
    }
}
