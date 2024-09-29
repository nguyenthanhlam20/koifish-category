using System;
using System.Collections.Generic;

namespace KoiDeliveryOrderSystem.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int? FishId { get; set; }

    public string? Health { get; set; }

    public bool? TimeTranport { get; set; }

    public string? PaymentMethod { get; set; }

    public int? Quantity { get; set; }

    public string? TranportBy { get; set; }

    public string? AddressFrom { get; set; }

    public string? AddressTo { get; set; }

    public string? Others { get; set; }

    public double? TotalPrice { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Customer User { get; set; } = null!;
}
