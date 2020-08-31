using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IDiseaseRepository
    {
        DiseaseDTO AddDisease(DiseaseDTO diseaseDTO);
        Disease Delete(int id);
        List<Disease> GetDisease();
        List<Disease> GetDiseaseId(int id);
        Disease Update(Disease diseaseChanges);
    }
}
