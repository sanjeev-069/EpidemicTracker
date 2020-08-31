using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        
        public UniqueIdType UniqueIdType { get; set; }

        public int Loginid { get; set; }
        public Login Login { get; set; }

        public Occupation Occupation { get; set; }

        public List<PatientAddress> PatientAddresses { get; set; }

        public List<TreatmentRecord> TreatmentRecords { get; set; }

    }
}
