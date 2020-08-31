using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Models
{
    public class Hospital
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalPhoneNumber { get; set; }

        public List<HospitalAddress> HospitalAddresses { get; set; }

        public List<TreatmentRecord> TreatmentRecords { get; set; }
    }
}
