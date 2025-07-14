using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DeliveryApi.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? TotalPrice { get; set; }
    [JsonIgnore]
    public virtual Order? Order { get; set; } = null!;
    [JsonIgnore]
    public virtual Product? Product { get; set; } = null!;
}
