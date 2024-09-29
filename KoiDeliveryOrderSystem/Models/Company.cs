using System;
using System.Collections.Generic;

namespace KoiDeliveryOrderSystem.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? TaxCode { get; set; }

    public string? ContactPersonName { get; set; }

    public string? ContactPersonEmail { get; set; }

    public string? ContactPersonPhone { get; set; }
}
