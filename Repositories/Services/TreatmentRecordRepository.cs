using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class TreatmentRecordRepository : ITreatmentRecordRepository
    {
        private List<TreatmentRecord> treatmentRecord;

        private EpidemicTrackerDbContext _context;
        public TreatmentRecordRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<TreatmentRecordDTO> GetTreatmentRecords()
        {
            //return _context.TreatmentRecords.ToList();
            var details = (from pat in _context.Patients

                           join uniqueid in _context.UniqueIdTypes on pat.PatientId equals uniqueid.Patientid

                           join addr in _context.PatientAddresses on pat.PatientId equals addr.Patientid
                           
                           join Treatment in _context.TreatmentRecords on pat.PatientId equals Treatment.PatientId

                           join hosp in _context.Hospitals on Treatment.Hospitalid equals hosp.HospitalId

                           join addrs in _context.HospitalAddresses on hosp.HospitalId equals addrs.Hospitalid

                           join tdetail in _context.TreatmentDetails on Treatment.Treatmentid equals tdetail.TreatmentId

                           join disease in _context.Diseases on Treatment.Diseaseid equals disease.DiseaseId

                           join stage in _context.Stages on tdetail.Stageid equals stage.StageId

                           join occp in _context.Occupations on pat.PatientId equals occp.Patientid
                           join address in _context.WorkAddresses on occp.OccupationId equals address.Occupationid

                           select new TreatmentRecordDTO()

                           {
                               PatientName = pat.PatientName,
                               PhoneNumber = pat.PhoneNumber,
                               Gender=pat.Gender,
                               Age=pat.Age,

                               UniqueIdType=uniqueid.UniqueidType,
                               UniqueidNumber=uniqueid.UniqueidNumber,

                               StreetNumber = addr.StreetNumber,
                               Area = addr.Area,
                               City = addr.City,
                               State = addr.State,
                               Country = addr.Country,
                               ZipCode = addr.ZipCode,

                               OrganisationName=occp.OrganisationName,
                               OrgPhoneNumber=occp.PhoneNumber,
                               WorkType=occp.WorkType,
                               Designation=occp.Designation,

                               Ocp_StreetNumber=address.StreetNumber,
                               Ocp_Area=address.Area,
                               Ocp_City=address.City,
                               Ocp_State=address.State,
                               Ocp_Country=address.Country,
                               Ocp_ZipCode=address.ZipCode,

                               HospitalName = hosp.HospitalName,
                               HospitalPhoneNumber = hosp.HospitalPhoneNumber,
                               Hosp_StreetNumber = addrs.StreetNumber,
                               Hosp_Area = addrs.Area,
                               Hosp_City = addrs.City,
                               Hosp_State = addrs.State,
                               Hosp_Country = addrs.Country,
                               Hosp_ZipCode = addrs.ZipCode,

                               AdmitDate = tdetail.AdmitDate,
                               RelievingDate = tdetail.RelievingDate,
                               IsFatality = tdetail.IsFatality,
                               Prescription = tdetail.Prescription,
                               
                               DiseaseType=disease.DiseaseType,


                               CurrentStage=stage.CurrentStage

                               



                           }
                          ).ToList();
            return details;
        }

        public List<TreatmentRecordDTO> GetTreatmentRecordsDetail()
        {
            //return _context.TreatmentRecords.ToList();
            var details = (from pat in _context.Patients



                           join addr in _context.PatientAddresses on pat.PatientId equals addr.Patientid

                           join Treatment in _context.TreatmentRecords on pat.PatientId equals Treatment.PatientId

                           join hosp in _context.Hospitals on Treatment.Hospitalid equals hosp.HospitalId



                           join tdetail in _context.TreatmentDetails on Treatment.Treatmentid equals tdetail.TreatmentId



                           join disease in _context.Diseases on Treatment.Diseaseid equals disease.DiseaseId
                          
                           join stage in _context.Stages on tdetail.Stageid equals stage.StageId
                           where tdetail.IsFatality.Equals("Dead")




                           select new TreatmentRecordDTO()

                           {
                               PatientId = pat.PatientId,

                               PatientName = pat.PatientName,
                               PhoneNumber = pat.PhoneNumber,
                               Gender = pat.Gender,
                               Age = pat.Age,

                               DiseaseType = disease.DiseaseType,
                               DiseaseName = disease.DiseaseName,
                               AdmitDate = tdetail.AdmitDate,
                               RelievingDate = tdetail.RelievingDate,
                               IsFatality = tdetail.IsFatality,
                               Prescription = tdetail.Prescription,

                               CurrentStage = stage.CurrentStage





                           }
                          ).ToList();
            return details;
        }

        public List<TreatmentRecordDTO> GetCuredDetails()
        {
            //return _context.TreatmentRecords.ToList();
            var details = (from pat in _context.Patients
                                                     
                           join addr in _context.PatientAddresses on pat.PatientId equals addr.Patientid
                           join uniqueid in _context.UniqueIdTypes on pat.PatientId equals uniqueid.Patientid
                           join Treatment in _context.TreatmentRecords on pat.PatientId equals Treatment.PatientId

                           join hosp in _context.Hospitals on Treatment.Hospitalid equals hosp.HospitalId

                           join tdetail in _context.TreatmentDetails on Treatment.Treatmentid equals tdetail.TreatmentId

                           join disease in _context.Diseases on Treatment.Diseaseid equals disease.DiseaseId
                           join occp in _context.Occupations on pat.PatientId equals occp.Patientid
                           join address in _context.WorkAddresses on occp.OccupationId equals address.Occupationid
                           join stage in _context.Stages on tdetail.Stageid equals stage.StageId
                           where stage.CurrentStage.Equals("Cured")




                           select new TreatmentRecordDTO()

                           {
                               PatientId=pat.PatientId,

                               PatientName = pat.PatientName,
                               PhoneNumber = pat.PhoneNumber,
                               Gender = pat.Gender,
                               Age = pat.Age,

                               DiseaseType=disease.DiseaseType,
                               DiseaseName=disease.DiseaseName,
                               AdmitDate = tdetail.AdmitDate,
                               RelievingDate = tdetail.RelievingDate,
                               IsFatality = tdetail.IsFatality,
                               Prescription = tdetail.Prescription,

                               CurrentStage = stage.CurrentStage





                           }
                          ).ToList();
            return details;
        }


        public List<TreatmentRecordDTO> GetUncuredDetails()
        {
            //return _context.TreatmentRecords.ToList();
            var details = (from pat in _context.Patients

                           join addr in _context.PatientAddresses on pat.PatientId equals addr.Patientid
                           join unique in _context.UniqueIdTypes on pat.PatientId equals unique.Patientid

                           join Treatment in _context.TreatmentRecords on pat.PatientId equals Treatment.PatientId

                           join hosp in _context.Hospitals on Treatment.Hospitalid equals hosp.HospitalId

                           join tdetail in _context.TreatmentDetails on Treatment.Treatmentid equals tdetail.TreatmentId

                           join disease in _context.Diseases on Treatment.Diseaseid equals disease.DiseaseId

                           join stage in _context.Stages on tdetail.Stageid equals stage.StageId
                           where (stage.CurrentStage.Equals("Minor") || stage.CurrentStage.Equals("Major"))


                           select new TreatmentRecordDTO()

                           {
                               PatientId = pat.PatientId,

                               PatientName = pat.PatientName,
                               PhoneNumber = pat.PhoneNumber,
                               Gender = pat.Gender,
                               Age = pat.Age,

                               DiseaseType = disease.DiseaseType,
                               DiseaseName = disease.DiseaseName,
                               AdmitDate = tdetail.AdmitDate,
                               RelievingDate = tdetail.RelievingDate,
                               IsFatality = tdetail.IsFatality,
                               Prescription = tdetail.Prescription,

                               CurrentStage = stage.CurrentStage






                           }
                          ).ToList();
            return details;
        }
        //public int GetCount()
        //{

        //    var details = (from record in _context.TreatmentRecords

        //                   select record.RecordId);


        //    return details.Count();
        //}




        public TreatmentRecordDTO AddTreatmentRecord(TreatmentRecordDTO treatmentRecordDTO)
        {
            var records = new TreatmentRecord()
            {
                PatientId = treatmentRecordDTO.PatientId,
                Hospitalid = treatmentRecordDTO.Hospitalid,
                Diseaseid = treatmentRecordDTO.Diseaseid,
                Treatmentid = treatmentRecordDTO.Treatmentid
            };
            _context.TreatmentRecords.Add(records);
            
            _context.SaveChanges();

            return treatmentRecordDTO;
        }

        public TreatmentRecord Delete(int id)
        {

            TreatmentRecord treatmentRecord = _context.TreatmentRecords.Find(id);
            if (treatmentRecord != null)
            {
                _context.TreatmentRecords.Remove(treatmentRecord);
                _context.SaveChanges();
            }
            return treatmentRecord;

        }
        public TreatmentRecord Update(TreatmentRecord treatmentRecordChanges)
        {

            var treatmentRecord = _context.TreatmentRecords.Attach(treatmentRecordChanges);
            treatmentRecord.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return treatmentRecordChanges;

        }

        public List<TreatmentRecord> GetTreatmentRecordbyId(int id)
        {

            //treatmentRecord = _context.TreatmentRecords.Where(l => l.RecordId == id).Select(l => new TreatmentRecord()
            //{
            //    PersonId = l.PersonId,
            //    Hospitalid = l.Hospitalid,
            //    Diseaseid = l.Diseaseid,
            //    Treatmentid = l.Treatmentid


            //}).ToList<TreatmentRecord>();

            treatmentRecord = _context.TreatmentRecords.Where(l => l.RecordId == id).ToList();
            return treatmentRecord;

        }

    }
}