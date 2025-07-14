using DeliveryApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliveryApp.ViewModels
{
    public class CartViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _cart = new ObservableCollection<Product>();
        public ObservableCollection<Product> cart
        {
            get => _cart;
            set
            {
                _cart = value;
                OnPropertyChanged(nameof(cart));
            }
        }

        User currentuser = new User();

        public CartViewModel()
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

        public async void removeCartItem(Product product)
        {
            var productToRemove = cart.FirstOrDefault(x => x.ProductName == product.ProductName);

            cart.Remove(productToRemove);

            updateCartPrefernces();
        }

        public async void incrementCartItem(Product product)
        {
            var productToIncrement = cart.FirstOrDefault(x => x.ProductName == product.ProductName);

            productToIncrement.Quantity += 1;

            updateCartPrefernces();


        }
        public async void decrementCartItem(Product product)
        {
            var productToDecremet = cart.FirstOrDefault(x => x.ProductName == product.ProductName);

            productToDecremet.Quantity -= 1;

            updateCartPrefernces();
        }
        private void updateCartPrefernces()
        {
            var serializedCart = JsonSerializer.Serialize(cart);
            Preferences.Set($"{currentuser.UserId}_cart", serializedCart);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
