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
    public class OccupationRepository : IOccupationRepository
    {
        private List<Occupation> occupation;

        private EpidemicTrackerDbContext _context;
        public OccupationRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<Occupation> GetOccupation()
        {
            return _context.Occupations.ToList();

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

        public List<Occupation> GetOccupationId(int id)
        {

            //occupation = _context.Occupations.Where(o => o.OccupationId == id).Select(o => new Occupation()
            //{
            //    OccupationName = o.OccupationName,
            //    OccupationType = o.OccupationType
            //}).ToList<Occupation>();
            occupation = _context.Occupations.Where(l => l.OccupationId == id).ToList();
            return occupation;
        }


        public Occupation Add(Occupation occupation)
        {
            _context.Occupations.Add(occupation);
            _context.SaveChanges();
            //_context.Occupations.Add(new Occupation()
            //{
            //    OccupationName = occupation.OccupationName,
            //    OccupationType = occupation.OccupationType
            //});
            //_context.SaveChanges();

            return occupation;
        }

        public Occupation Delete(int id)
        {

            Occupation occupation = _context.Occupations.Find(id);
            if (occupation != null)
            {
                _context.Occupations.Remove(occupation);
                _context.SaveChanges();
            }
            return occupation;

        }
        public Occupation Update(Occupation occupationChanges)
        {

            var occupation = _context.Occupations.Attach(occupationChanges);
            occupation.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return occupationChanges;



        }

        public OccupationDTO AddOccupation(OccupationDTO occupationDTO)
        {
            var occp = new Occupation()
            {
                OrganisationName = occupationDTO.OrganisationName,
                PhoneNumber=occupationDTO.PhoneNumber,
                WorkType=occupationDTO.WorkType,
                Designation=occupationDTO.Designation,
                Patientid=occupationDTO.Patientid                          
            };
            _context.Occupations.Add(occp);
            _context.SaveChanges();
            int Occpid = occp.OccupationId;

            var addr = new WorkAddress()
            {
                StreetNumber = occupationDTO.StreetNumber,
                Area = occupationDTO.Area,
                City = occupationDTO.City,
                State = occupationDTO.State,
                Country = occupationDTO.Country,
                ZipCode = occupationDTO.ZipCode,
                Occupationid=Occpid
            };

            _context.WorkAddresses.Add(addr);
            _context.SaveChanges();
            return occupationDTO;
        }
    }
}

