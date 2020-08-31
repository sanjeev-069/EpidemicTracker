using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Models
{
    public class TreatmentRecord
    {
        public int RecordId { get; set; }

        public int PatientId { get; set; }
        public Patient Patient{ get; set; }


        public int Hospitalid { get; set; }
        public Hospital Hospital { get; set; }

        public int Diseaseid { get; set; }
        public Disease Disease { get; set; }

        public int Treatmentid { get; set; }
        public TreatmentDetail TreatmentDetails { get; set; }
    }
}
