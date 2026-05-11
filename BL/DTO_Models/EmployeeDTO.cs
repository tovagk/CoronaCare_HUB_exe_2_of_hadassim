using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO_Models
{
    public class EmployeeDTO
    {
        public string? Idnumber { get; set; }
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? AddressId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? MobilePhone { get; set; }
        public string? CityName { get; set; } 
        public string? StreetName { get; set;}
        public string? StreetNumber { get; set;}
        public CovidDetailDTO CovidDetail { get; set; }

    }
}
