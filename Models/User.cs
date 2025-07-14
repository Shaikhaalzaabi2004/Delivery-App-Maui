using System;
using System.Collections.Generic;

namespace DeliveryApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; } = null!;
}
