namespace DeliveryApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("CreateAccountPage", typeof(CreateAccountPage));
            //Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("CatalogPage", typeof(CatalogPage));
            Routing.RegisterRoute("CartPage", typeof(CartPage));
            Routing.RegisterRoute("CheckoutPage", typeof(CheckoutPage));
        }
    }
}
