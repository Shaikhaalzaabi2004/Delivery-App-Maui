using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DeliveryApi.Models;

public class Product : INotifyPropertyChanged
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public int? CategoryId { get; set; }

    private int _quantity = 1;
    public int Quantity
    {
        get => _quantity;
        set
        {
             _quantity = value;
             OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(PricePerProduct));
        }
    }
    public decimal PricePerProduct => Quantity * Price;

    public bool IsAvailable { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
