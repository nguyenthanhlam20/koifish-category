using System;
using System.Collections.Generic;

namespace KoiDeliveryOrderSystem.Models;

public partial class Declaration
{
    public int DeclarationId { get; set; }

    public DateOnly? DeclarationDate { get; set; }

    public double? TotalValue { get; set; }

    public int? ExporterId { get; set; }

    public string? CompanyName { get; set; }

    public string? TaxCode { get; set; }

    public int? ImporterId { get; set; }

    public string? ShippingMethod { get; set; }

    public string? DeparturePort { get; set; }

    public string? ArrivalPort { get; set; }

    public string? GoodsDescription { get; set; }

    public string? Hscode { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
