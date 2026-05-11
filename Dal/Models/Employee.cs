using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Idnumber { get; set; }

    public int? AddressId { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Phone { get; set; }

    public string? MobilePhone { get; set; }

    public virtual Address? Address { get; set; }

    public virtual CovidDetail? CovidDetail { get; set; }
}
