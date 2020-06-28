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
    public class DiseaseRepository : IDiseaseRepository
    {
        private List<Disease> disease;

        private EpidemicTrackerDbContext _context;
        public DiseaseRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<Disease> GetDisease()
        {
            return _context.Diseases.ToList();

            //login = _context.Logins.Select(l => new Login()
            //{

            //    LoginId = l.LoginId,
            //    Name = l.Name,
            //    Gender = l.Gender,
            //    Email = l.Email,
            //    PhoneNumber = l.PhoneNumber,
            //    Password = l.Password

            //}).ToList<Login>();
            //_context.SaveChanges();
            //       return login;
        }

        public List<Disease> GetDiseaseId(int id)
        {

            //disease = _context.Diseases.Where(d => d.DiseaseId == id).Select(d => new Disease()
            //{
            //    DiseaseName = d.DiseaseName,
            //    DiseaseType = d.DiseaseType
            //}).ToList<Disease>();
            disease = _context.Diseases.Where(d => d.DiseaseId == id).ToList();
            return disease;
        }


        public DiseaseDTO AddDisease(DiseaseDTO diseaseDTO)
        {
            var diseases = new Disease()
            {
                DiseaseName = diseaseDTO.DiseaseName,
                DiseaseType = diseaseDTO.DiseaseType
            };
            _context.Diseases.Add(diseases);
            _context.SaveChanges();
            int diseaseid = diseases.DiseaseId;
            diseaseDTO.Diseaseid = diseaseid;
            //_context.Diseases.Add(new Disease()
            //{
            //    DiseaseName = disease.DiseaseName,
            //    DiseaseType = disease.DiseaseType
            //});
            

            return diseaseDTO;
        }

        public Disease Delete(int id)
        {

            Disease disease = _context.Diseases.Find(id);
            if (disease != null)
            {
                _context.Diseases.Remove(disease);
                _context.SaveChanges();
            }
            return disease;

        }
        public Disease Update(Disease diseaseChanges)
        {

            var disease = _context.Diseases.Attach(diseaseChanges);
            disease.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return diseaseChanges;



        }
    }
}

