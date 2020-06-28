using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Models
{
    public class Stage
    {
        public int StageId { get; set; }
        public string CurrentStage { get; set; }

        public List<TreatmentDetail> TreatmentDetails { get; set; }
    }
}
    