using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Entities
{
    public class DiseaseDTO
    {
        public int Diseaseid { get; set; }
        public string DiseaseName { get; set; }
        public string DiseaseType { get; set; }
    }
}
