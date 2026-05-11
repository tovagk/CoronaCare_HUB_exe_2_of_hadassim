using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class VaccineManufacturer
{
    public int ManufacturerId { get; set; }

    public string? ManufacturerName { get; set; }

    public virtual ICollection<CovidDetail> CovidDetails { get; } = new List<CovidDetail>();
}
