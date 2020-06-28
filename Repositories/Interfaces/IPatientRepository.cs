using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        
        Patient Delete(int id);
        //List<Patient> GetPatientbyId(int id);
        Patient Update(Patient PatientChanges);
        PatientDTO AddPatient(PatientDTO PatientDTO);
        List<PatientDTO> GetPatientDetail();
    }

}
