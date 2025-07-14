using DeliveryApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliveryApp.ViewModels
{

    public class CheckoutViewModel
    {
        public ObservableCollection<Product> cart { get; set; } = new ObservableCollection<Product>();
      
        public User currentuser = new User();
        public CheckoutViewModel()
        {
            loadCart();
        }
        private void loadCart()
        {
            string currentUserJson = Preferences.Get("@currentUser", string.Empty);

            currentuser = JsonSerializer.Deserialize<User>(currentUserJson);

            var jsonCart = Preferences.Get($"{currentuser.UserId}_cart", string.Empty);

            if (!string.IsNullOrEmpty(jsonCart))
            {
                var cartJson = JsonSerializer.Deserialize<List<Product>>(jsonCart);
                foreach (var item in cartJson)
                {
                    cart.Add(item);
                }
            }
        }

        public void clearCart()
        {
            cart.Clear();

            var jsonCart = JsonSerializer.Serialize(cart);

            Preferences.Set($"{currentuser.UserId}_cart", jsonCart);

        }
    }
}
