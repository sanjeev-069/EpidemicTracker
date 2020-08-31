using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Entities
{
    public class TreatmentRecordDTO
    {
        public int RecordId { get; set; }

        public int PatientId { get; set; }

        public int Hospitalid { get; set; }

        public int Diseaseid { get; set; }
        public int Treatmentid { get; set; }


        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public string DiseaseType { get; set; }
        public string DiseaseName { get; set; }
        public string UniqueIdType { get; set; }
        public string UniqueidNumber { get; set; }
        public string StreetNumber { get; set; }
        public string Area { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public int OccupationId { get; set; }
        public string OrganisationName { get; set; }
        public string OrgPhoneNumber { get; set; }
        public string WorkType { get; set; }
        public string Designation { get; set; }

        

        public string Ocp_StreetNumber { get; set; }
        public string Ocp_Area { get; set; }
        public string Ocp_City { get; set; }
        public string Ocp_State { get; set; }
        public string Ocp_Country { get; set; }
        public string Ocp_ZipCode { get; set; }

        public string HospitalName { get; set; }
        public string HospitalPhoneNumber { get; set; }


        public string Hosp_StreetNumber { get; set; }
        public string Hosp_Area { get; set; }

        public string Hosp_City { get; set; }
        public string Hosp_State { get; set; }
        public string Hosp_Country { get; set; }
        public string Hosp_ZipCode { get; set; }


        
        public DateTime AdmitDate { get; set; }
        public string Prescription { get; set; }
        public DateTime RelievingDate { get; set; }
        public string IsFatality { get; set; }

        public string CurrentStage { get; set; }
    }
}
