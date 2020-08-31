using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Entities
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public int Loginid { get; set; }
        
        public string UniqueIdType { get; set; }
        public string UniqueidNumber { get; set; }
        public string StreetNumber { get; set; }
        public string Area { get; set; }
       
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
