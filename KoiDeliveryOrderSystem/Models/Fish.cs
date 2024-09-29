using System;
using System.Collections.Generic;

namespace KoiDeliveryOrderSystem.Models;

public partial class Fish
{
    public int FishId { get; set; }

    public int? FishTypeId { get; set; }

    public int? Size { get; set; }

    public string? Color { get; set; }

    public string? Food { get; set; }

    public string? Environment { get; set; }

    public string? SharpBody { get; set; }

    public string? Breed { get; set; }

    public string? Illness { get; set; }

    public int? Age { get; set; }

    public virtual FishCategory? FishType { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
