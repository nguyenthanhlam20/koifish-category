﻿using System;
using System.Collections.Generic;

namespace KoiDeliveryOrderSystem.Models;

public partial class Customer
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
