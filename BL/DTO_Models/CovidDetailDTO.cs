using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO_Models
{
    public class CovidDetailDTO
    {
        public string? EmployeeNumberId { get; set; }
        public DateTime? FirstVaccineDate { get; set; }
        public DateTime? SecondVaccineDate { get; set; }
        public DateTime? ThirdVaccineDate { get; set; }
        public DateTime? FourthVaccineDate { get; set; }
        public string? VaccineManufacturerName { get; set; }
        public DateTime? PositiveTestDate { get; set; }
        public DateTime? RecoveryDate { get; set; }

    }
}
