using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Entities
{
    public class OccupationDTO
    {
        public int OccupationId { get; set; }
        public string OrganisationName { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkType { get; set; }
        public string Designation { get; set; }

        public int Patientid { get; set; }

        public string StreetNumber { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
