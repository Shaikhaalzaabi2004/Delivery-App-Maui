using DeliveryApp.Helper;
using DeliveryApi.Models;
using System.Text.Json;
using Microsoft.Maui.Platform;

namespace DeliveryApp;

public partial class CreateAccountPage : ContentPage
{
    ApiRequests api = new ApiRequests();
	public CreateAccountPage()
	{
		InitializeComponent();
	}
    private bool validateInputs()
    {
        if(string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(nameEntry.Text) || string.IsNullOrEmpty(passEntry.Text) || string.IsNullOrEmpty(confirmEntry.Text))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool validatePassword()
    {
        if(passEntry.Text != confirmEntry.Text)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool validateEmail()
    {
        if(!emailEntry.Text.Contains("@"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private async Task<User> registerUser(User toRegister)
    {
        return await api.registerResult(toRegister);
    }
    private async void createAccountBtn_Clicked(object sender, EventArgs e)
    {
        if (!validateInputs()) {
            DisplayAlert("Error", "Please Input All Required Fields", "Return");
        }
        else
        {
            if (!validatePassword()) {
                DisplayAlert("Error", "Passwords Do Not Match", "Return");
            }
            else
            {
                if (!validateEmail())
                {
                    DisplayAlert("Error", "Email Format Invalid", "Return");
                }
                else
                {
                        User newUser = new User()
                        {
                            FullName = nameEntry.Text,
                            Email = emailEntry.Text,
                            PasswordHash = passEntry.Text,
                        };

                    var result = await registerUser(newUser);

                    if (!string.IsNullOrEmpty(result.FullName))
                    {
                        DisplayAlert("Success", "Registered Successfully", "Return");

                        await Shell.Current.GoToAsync("//MainPage");
                    }

                }
            }
        }
    }

    private async void cancelBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MainPage");
    }
}