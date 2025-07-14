using DeliveryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliveryApp.Helper
{
    public class ApiRequests
    {
        ApiClient client = new ApiClient();

<<<<<<< HEAD
        string url = "http://192.168.30.198:5261/api/";
=======
        string url = "http://10.17.106.213:5261/api/";
>>>>>>> origin/master


        JsonSerializerOptions options = new JsonSerializerOptions() {
            PropertyNameCaseInsensitive = true,
        };

        public async Task<User> loginResult(LoginRequest loginRequest)
        {
            var fullUrl = url + "users/login";
            var result = await client.httpClient.PostAsJsonAsync(fullUrl, loginRequest);

            if (result.IsSuccessStatusCode) {
                var user = await result.Content.ReadFromJsonAsync<User>(options);
                return user;
            }
            else
            {
                return new User();
            }
        }
        public async Task<User> registerResult(User userToRegister)
        {
            var fullUrl = url + "users/register";
            var result = await client.httpClient.PostAsJsonAsync(fullUrl, userToRegister);

            if (result.IsSuccessStatusCode) {
                var user = await result.Content.ReadFromJsonAsync<User>(options);
                return user;
            }
            else
            {
                return new User();
            }
        }

        public async Task<List<Product>> getProducts()
        {
            var fullUrl = url + "products";
            var products = await client.httpClient.GetFromJsonAsync<List<Product>>(fullUrl);

            if (products.Count != 0) {
                return products;
            }
            else
            {
                return new List<Product>();
            }
        }

        public async Task<bool> placeOrderResult(Order orderToPlace)
        {
            var fullUrl = url + "orders";
            var responseMessage = await client.httpClient.PostAsJsonAsync(fullUrl, orderToPlace);

            if (responseMessage.IsSuccessStatusCode) {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
