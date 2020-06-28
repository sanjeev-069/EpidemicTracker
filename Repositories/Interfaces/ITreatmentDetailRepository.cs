using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface ITreatmentDetailRepository
    {
        TreatmentDetailDTO AddTreatment(TreatmentDetailDTO TreatmentDetailDTO);
        TreatmentDetail Delete(int id);
        List<TreatmentDetail> GetTreatmentDetailbyId(int id);
        List<TreatmentDetail> GetTreatmentDetails();
        TreatmentDetail Update(TreatmentDetail treatmentDetailChanges);
    }
}
