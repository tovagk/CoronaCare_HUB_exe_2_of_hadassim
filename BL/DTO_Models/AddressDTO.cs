using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO_Models
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public int? StreetId { get; set; }
        public string? StreetNumber { get; set; }
        public string? StreetName { get; set; } 
        public string? CityName { get; set; } 
    }
}
