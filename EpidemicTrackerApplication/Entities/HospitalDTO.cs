using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Entities
{
    public class HospitalDTO
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalPhoneNumber { get; set; }


        public string StreetNumber { get; set; }
        public string Area { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
