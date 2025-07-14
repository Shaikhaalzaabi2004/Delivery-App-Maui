using DeliveryApp.ViewModels;
using DeliveryApi.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DeliveryApp;

public partial class CatalogPage : ContentPage
{
    CatalogViewModel catalogViewModel = new CatalogViewModel();
    ObservableCollection<Product> localCart = new ObservableCollection<Product>();
    User currentuser = new User();

    public CatalogPage()
    {
        InitializeComponent();
        BindingContext = catalogViewModel;

        string currentUserJson = Preferences.Get("@currentUser", string.Empty);

        if (!string.IsNullOrEmpty(currentUserJson))
        {
            currentuser = JsonSerializer.Deserialize<User>(currentUserJson);
        }

        var jsonCart = Preferences.Get($"{currentuser.UserId}_cart", string.Empty);

        if (!string.IsNullOrEmpty(jsonCart))
        {
            var cart = JsonSerializer.Deserialize<List<Product>>(jsonCart);
            foreach (var item in cart)
            {
                localCart.Add(item);
            }
        }

        refreshCartQuantity();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        refreshCartQuantity();
    }

    private int getCartItemQuantity()
    {
        var count = 0;
        foreach (var item in localCart)
        {
            count += item.Quantity;
        }
        return count;
    }

    private void refreshCartQuantity()
    {
        var cartItemTotal = getCartItemQuantity();
        numberOfItems.Text = cartItemTotal.ToString() + " items";
    }

    private void addToCartBtn_Clicked(object sender, EventArgs e)
    {
        var senderObj = sender as Button;
        var item = senderObj.BindingContext as Product;

        if (item != null)
        {
            var jsonCart = Preferences.Get($"{currentuser.UserId}_cart", string.Empty);
            List<Product> cartItems = new List<Product>();

            if (!string.IsNullOrEmpty(jsonCart))
            {
                cartItems = JsonSerializer.Deserialize<List<Product>>(jsonCart);
            }

            var existingItem = cartItems.FirstOrDefault(p => p.ProductName == item.ProductName);

            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                var newItem = new Product
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = 1,
                };
                cartItems.Add(newItem);
            }

            localCart.Clear();
            foreach (var _item in cartItems)
            {
                localCart.Add(_item);
            }

            var cartSerialized = JsonSerializer.Serialize(cartItems);
            Preferences.Set($"{currentuser.UserId}_cart", cartSerialized);

            DisplayAlert("Success", "Item added to cart", "Return");
            refreshCartQuantity();
        }
        else
        {
            DisplayAlert("Error", "Could not add item to cart", "Return");
        }
    }

    private async void cartImage_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("CartPage");
    }
}
