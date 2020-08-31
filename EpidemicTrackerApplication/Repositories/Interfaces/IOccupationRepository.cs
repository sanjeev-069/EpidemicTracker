using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IOccupationRepository
    {
        //Occupation Add(Occupation occupation);
        OccupationDTO AddOccupation(OccupationDTO occupationDTO);
        Occupation Delete(int id);
        List<Occupation> GetOccupation();
        List<Occupation> GetOccupationId(int id);
        Occupation Update(Occupation occupationChanges);
    }
}
