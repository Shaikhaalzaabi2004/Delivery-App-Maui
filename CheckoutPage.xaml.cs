
using DeliveryApi.Models;
using DeliveryApp.Helper;
using DeliveryApp.ViewModels;

namespace DeliveryApp;

public partial class CheckoutPage : ContentPage
{
	CheckoutViewModel CheckoutViewModel = new CheckoutViewModel();
	decimal total = 0;
	ApiRequests api = new ApiRequests();
	public CheckoutPage()
	{
		InitializeComponent();

		BindingContext = CheckoutViewModel;

        foreach (var product in CheckoutViewModel.cart)
        {
            total = total + (product.Price * product.Quantity);
        }

        summaryText.Text = "Cart Total: " + total.ToString();
    }
	private bool validateRequiredFields()
	{
		if(string.IsNullOrEmpty(addressEntry.Text) || string.IsNullOrEmpty(phoneEntry.Text))
		{
			return false; 
		}
		return true;
	}
    private async void confirmOrderBtn_Clicked(object sender, EventArgs e)
    {
		if (!validateRequiredFields())
		{
			DisplayAlert("Error", "Please Input All Required Fields", "Return");
		}
		else
		{
			List<OrderItem> orderItems = new List<OrderItem>();

			foreach (var product in CheckoutViewModel.cart)
			{
				orderItems.Add(new OrderItem()
				{
					ProductId = product.ProductId,
					Quantity = product.Quantity,
					UnitPrice = product.Price,
					TotalPrice = product.Quantity * product.Price
				}
				);

			}

			Order newOrder = new Order()
			{
				UserId = CheckoutViewModel.currentuser.UserId,
				DeliveryAddress = addressEntry.Text,
				PhoneNumber = phoneEntry.Text,
				TotalAmount = total,
				Status = "Pending"
			};

			if (!string.IsNullOrEmpty(notesEntry.Text))
			{
				newOrder.Notes = notesEntry.Text;
			}

			newOrder.OrderItems = orderItems;


			var result = await placeOrderResult(newOrder);

			if (result)
			{
				DisplayAlert("Success", "Order Placed Successfully", "Return");

				CheckoutViewModel.clearCart();

				await Shell.Current.GoToAsync("CatalogPage");
			}
			else
			{
                DisplayAlert("Error", "Could Not Place Order", "Return");

            }
        }
    }

	private async Task<bool> placeOrderResult(Order order)
	{
		return await api.placeOrderResult(order);
	}
}