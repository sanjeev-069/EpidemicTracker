using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Models
{
    public class UniqueIdType
    {
        public int UniqueId { get; set; }

        public string UniqueidType { get; set; }

        public string UniqueidNumber { get; set; }

        public int Patientid { get; set; }
        public Patient Patient { get; set; }
    }
}
