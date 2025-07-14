using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DeliveryApi.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public string DeliveryAddress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Notes { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    [JsonIgnore]
    public virtual User? User { get; set; } = null!;
}
