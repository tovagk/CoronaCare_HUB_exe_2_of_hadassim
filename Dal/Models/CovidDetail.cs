using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class CovidDetail
{
    public int EmployeeId { get; set; }

    public DateTime? FirstVaccineDate { get; set; }

    public DateTime? SecondVaccineDate { get; set; }

    public DateTime? ThirdVaccineDate { get; set; }

    public DateTime? FourthVaccineDate { get; set; }

    public int? VaccineManufacturerId { get; set; }

    public DateTime? PositiveTestDate { get; set; }

    public DateTime? RecoveryDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual VaccineManufacturer? VaccineManufacturer { get; set; }
}
