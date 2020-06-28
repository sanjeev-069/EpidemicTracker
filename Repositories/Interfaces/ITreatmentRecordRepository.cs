using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface ITreatmentRecordRepository
    {
        TreatmentRecordDTO AddTreatmentRecord(TreatmentRecordDTO treatmentRecordDTO);
        TreatmentRecord Delete(int id);
        List<TreatmentRecordDTO> GetCuredDetails();
        List<TreatmentRecordDTO> GetUncuredDetails();
        List<TreatmentRecord> GetTreatmentRecordbyId(int id);
        List<TreatmentRecordDTO> GetTreatmentRecords();
       List<TreatmentRecordDTO> GetTreatmentRecordsDetail();
        TreatmentRecord Update(TreatmentRecord treatmentRecordChanges);
    }
}
