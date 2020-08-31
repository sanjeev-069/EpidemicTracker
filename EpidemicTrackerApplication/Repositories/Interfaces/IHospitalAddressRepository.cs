using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IHospitalAddressRepository
    {
        HospitalAddress Add(HospitalAddress address);
        HospitalAddress Delete(int id);
        List<HospitalAddress> GetAddress();
        List<HospitalAddress> GetAddressId(int id);
        HospitalAddress Update(HospitalAddress addressChanges);
    }
}
