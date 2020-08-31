using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IPatientAddressRepository
    {
        PatientAddress Add(PatientAddress address);
        PatientAddress Delete(int id);
        List<PatientAddress> GetAddress();
        List<PatientAddress> GetAddressId(int id);
        PatientAddress Update(PatientAddress addressChanges);
    }
}

