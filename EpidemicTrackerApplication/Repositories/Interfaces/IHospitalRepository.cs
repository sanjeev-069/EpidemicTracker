using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IHospitalRepository
    {
        HospitalDTO AddHospital(HospitalDTO hospitalDTO);
        Hospital Delete(int id);
        //List<Hospital> GetHospital();
        List<HospitalDTO> GetHospitalDetail();
        List<HospitalDTO> GetHospitalId(int id);
        HospitalDTO Update(int id,HospitalDTO hospitalChanges);
    }
}
