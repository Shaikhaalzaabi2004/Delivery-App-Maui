using DeliveryApp.Helper;
using DeliveryApi.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliveryApp
{
    public partial class MainPage : ContentPage
    {
        ApiRequests api = new ApiRequests();

        public MainPage()
        {
            InitializeComponent();
        }


        private async void createAccountLink_Tapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync("CreateAccountPage");
        }

        private async void loginBtn_Clicked(object sender, EventArgs e)
        {
            if (!validateInputs())
            {
                DisplayAlert("Error", "Please Input All Required Fields", "Return");
            }
            else
            {
                LoginRequest loginRequest = new LoginRequest() {
                    Email = emailEntry.Text,
                    PasswordHash = passEntry.Text,
                };

                var result = await loginUser(loginRequest);

                if (!string.IsNullOrEmpty(result.FullName))
                {
                    var jsonCustomer = JsonSerializer.Serialize(result);

                    Preferences.Set("@currentUser", jsonCustomer);

                    await Shell.Current.GoToAsync("CatalogPage");
                }
                else
                {
                    DisplayAlert("Error", "Invalid Credentials", "Return");
                }
            }

        }
        private bool validateInputs()
        {
            if(string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(passEntry.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private async Task<User> loginUser(LoginRequest loginRequest)
        {
            return await api.loginResult(loginRequest);
        }  
    }
}
