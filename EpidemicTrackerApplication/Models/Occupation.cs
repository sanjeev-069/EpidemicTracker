using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Models
{
    public class Occupation
    {
        public int OccupationId { get; set; }
        public string OrganisationName { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkType { get; set; }
        public string Designation { get; set; }

        public int Patientid { get; set; }
        public Patient Patient { get; set; }

        
        public List<WorkAddress> WorkAddresses { get; set; }
    }
}
