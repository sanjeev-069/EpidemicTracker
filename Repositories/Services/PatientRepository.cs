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
        public Patient Update(Patient PatientChanges)
        {

            var Patient = _context.Patients.Attach(PatientChanges);
            Patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return PatientChanges;

        }

    }
}
