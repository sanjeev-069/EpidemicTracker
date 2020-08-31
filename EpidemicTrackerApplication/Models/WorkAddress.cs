using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Models
{
    public class WorkAddress
    {
        public int AddressId { get; set; }
        public string StreetNumber { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public int Occupationid { get; set; }
        public Occupation Occupation { get; set; }
    }
}
