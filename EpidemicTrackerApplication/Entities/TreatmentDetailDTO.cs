using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Entities
{
    public class TreatmentDetailDTO
    {
        public int TreatmentId { get; set; }
        public DateTime AdmitDate { get; set; }
        public string Prescription { get; set; }
        public DateTime RelievingDate { get; set; }
        public string IsFatality { get; set; }


        public int Stageid { get; set; }
    }
}
