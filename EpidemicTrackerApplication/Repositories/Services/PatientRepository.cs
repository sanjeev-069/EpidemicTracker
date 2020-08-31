using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class PatientRepository : IPatientRepository
    {
       // private List<Patient> Patient;

        private EpidemicTrackerDbContext _context;
        public PatientRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }




        public List<PatientDTO> GetPatientDetail()
        {


            var details = (from Patient in _context.Patients
                           join addr in _context.PatientAddresses
                           on Patient.PatientId equals addr.Patientid
                           select new PatientDTO()
                           {
                               PatientId=Patient.PatientId,
                               PatientName = Patient.PatientName,
                               Gender = Patient.Gender,
                               Age = Patient.Age,
                               PhoneNumber = Patient.PhoneNumber,
                               StreetNumber = addr.StreetNumber,
                               Area = addr.Area,
                               City = addr.City,
                               State = addr.State,
                               Country = addr.Country,
                               ZipCode = addr.ZipCode


                           }).ToList();


            return details;


        }


        public PatientDTO AddPatient(PatientDTO PatientDTO)
        {

            
            var Patients = new Patient()
            {
                
                PatientName = PatientDTO.PatientName,
                Age = PatientDTO.Age,
                Gender = PatientDTO.Gender,
                PhoneNumber = PatientDTO.PhoneNumber,
                Loginid = PatientDTO.Loginid
                

            };

            _context.Patients.Add(Patients);
            _context.SaveChanges();
            int Patientid = Patients.PatientId;
            

            PatientAddress addr = new PatientAddress()
            {
                StreetNumber = PatientDTO.StreetNumber,
                Area = PatientDTO.Area,
                City = PatientDTO.City,
                State = PatientDTO.State,
                Country = PatientDTO.Country,
                ZipCode = PatientDTO.ZipCode,
                Patientid = Patientid

            };
            _context.PatientAddresses.Add(addr);
            _context.SaveChanges();

            var uid = new UniqueIdType()
            {
                UniqueidType = PatientDTO.UniqueIdType,
                UniqueidNumber = PatientDTO.UniqueidNumber,
                Patientid = Patientid

            };
            _context.UniqueIdTypes.Add(uid);
            _context.SaveChanges();

            PatientDTO.PatientId = Patientid;
            return PatientDTO;
        }

        public Patient Delete(int id)
        {

            //var details = (from Patient in _context.Patients
            //               join addr in _context.PatientAddresses
            //               on Patient.PatientId equals addr.Patientid
            //               join occp in _context.Occupations
            //               on Patient.PatientId equals occp.Patientid
            //               join ocpadr in _context.WorkAddresses
            //               on occp.OccupationId equals ocpadr.Occupationid
            //               join treatments in _context.TreatmentRecords
            //               on Patient.PatientId equals treatments.PatientId
            //               join unique in _context.UniqueIdTypes
            //               on Patient.PatientId equals unique.Patientid
            //               where Patient.PatientId==id
                           //select new Patient());

           var details= _context.Patients.Include(a => a.PatientAddresses).Include(a => a.Occupation).Include(a=>a.UniqueIdType).Include(a => a.TreatmentRecords).FirstOrDefault(x => x.PatientId == id);
            //Patient Patient = _context.Patients.Find(id);
            if (details!= null)
            {

                _context.Patients.Remove(details);
                _context.SaveChanges();
            }
            return details;

        }
        public PatientDTO Update(int id,PatientDTO patientDTO)
        {

            var patients = _context.Patients.FirstOrDefault(p => p.PatientId == id);
            {
                patients.PatientName = patientDTO.PatientName;
                patients.PhoneNumber = patientDTO.PhoneNumber;
                patients.Gender = patientDTO.Gender;
                patients.Age = patientDTO.Age;
                
            }
            
            _context.SaveChanges();
            return patientDTO;
        
        }

        public TreatmentRecordDTO Update(int id, TreatmentRecordDTO treatmentRecordDTO)
        {



            var patients = _context.Patients.FirstOrDefault(p => p.PatientId == id);
            {
                patients.PatientName = treatmentRecordDTO.PatientName;
                patients.PhoneNumber = treatmentRecordDTO.PhoneNumber;
                patients.Gender = treatmentRecordDTO.Gender;
                patients.Age = treatmentRecordDTO.Age;
            }
            var records = _context.TreatmentRecords.FirstOrDefault(t => t.PatientId == patients.PatientId);
            var treatement = _context.TreatmentDetails.FirstOrDefault(x => x.TreatmentId == records.Treatmentid);
            {
                treatement.AdmitDate = treatmentRecordDTO.AdmitDate;
                treatement.RelievingDate = treatmentRecordDTO.RelievingDate;
                treatement.IsFatality = treatmentRecordDTO.IsFatality;
                treatement.Prescription = treatmentRecordDTO.Prescription;
            }
            var stage = _context.Stages.FirstOrDefault(s => s.StageId == treatement.Stageid);
            {
                stage.CurrentStage = treatmentRecordDTO.CurrentStage;

            }
            var disease = _context.Diseases.FirstOrDefault(d => d.DiseaseId == records.Diseaseid);
            {
                disease.DiseaseName = treatmentRecordDTO.DiseaseName;
                disease.DiseaseType = treatmentRecordDTO.DiseaseType;
            }
            _context.SaveChanges();
            return treatmentRecordDTO;


        }

    }
}
