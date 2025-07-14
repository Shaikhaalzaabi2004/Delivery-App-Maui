using DeliveryApp.Helper;
using DeliveryApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DeliveryApp.ViewModels
{
    public class CatalogViewModel : INotifyPropertyChanged

    {
        ApiRequests api = new ApiRequests();
        private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        public ObservableCollection<Product> products  {
            get => _products;
            set {
                _products = value;
                OnPropertyChanged(nameof(products));
            } 
        }

        public CatalogViewModel() {
            loadProducts();
        }

        public async void loadProducts()
        {
            var productList = await getProducts();
            foreach (var product in productList) {
                products.Add(product);
            }
        }

        private async Task<List<Product>> getProducts()
        {
            return await api.getProducts();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
