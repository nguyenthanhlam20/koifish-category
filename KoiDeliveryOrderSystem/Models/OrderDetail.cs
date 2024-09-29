using System;
using System.Collections.Generic;

namespace KoiDeliveryOrderSystem.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? FishId { get; set; }

    public string? Health { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public string? Certificate { get; set; }

    public string? SetUp { get; set; }

    public int? DeclarationId { get; set; }

    public int? CompanyId { get; set; }

    public virtual Declaration? Declaration { get; set; }

    public virtual Fish? Fish { get; set; }

    public virtual Order? Order { get; set; }
}
