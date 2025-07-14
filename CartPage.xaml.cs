using DeliveryApp.ViewModels;
using DeliveryApi.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DeliveryApp;

public partial class CartPage : ContentPage
{
    CartViewModel viewModel = new CartViewModel();
    User currentuser = new User();
    public CartPage()
	{
		InitializeComponent();

        BindingContext = viewModel;

        refreshTotalSummary();
    }
    private void refreshTotalSummary()
    {
        decimal total = 0;

        foreach (var product in viewModel.cart) {
            total = total + (product.Price * product.Quantity);
        }

        summaryText.Text = "Cart Total: " + total.ToString();
    }

    private void removeBtn_Clicked(object sender, EventArgs e)
    {
        var senderObj = sender as Button;
        var item = senderObj.BindingContext as Product;

        viewModel.cart.Remove(item);

        refreshTotalSummary();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // -

        var senderObj = sender as Button;
        var item = senderObj.BindingContext as Product;

        if (item == null) return;

        if (item.Quantity == 1)
        {
            viewModel.cart.Remove(item);
        }
        else
        {
            viewModel.decrementCartItem(item);
        }

        refreshTotalSummary();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        // +

        var senderObj = sender as Button;
        var item = senderObj.BindingContext as Product;

        if (item == null) return;

        viewModel.incrementCartItem(item);

        refreshTotalSummary();
    }



    private async void checkoutBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("CheckoutPage");
    }
}