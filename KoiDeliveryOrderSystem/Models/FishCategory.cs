using System;
using System.Collections.Generic;

namespace KoiDeliveryOrderSystem.Models;

public partial class FishCategory
{
    public int FishTypeId { get; set; }

    public string? FishName { get; set; }

    public int? MinSize { get; set; }

    public int? MaxSize { get; set; }

    public double? MinPrice { get; set; }

    public double? MaxPrice { get; set; }

    public string? Breed { get; set; }

    public string? Origin { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Fish> Fish { get; set; } = new List<Fish>();
}
