using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class HospitalRepository : IHospitalRepository
    {
        private List<HospitalDTO> hospital;
        private readonly EpidemicTrackerDbContext _context;
        public HospitalRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }

       
        public List<HospitalDTO> GetHospitalDetail()
        {
            var details = (from hosp in _context.Hospitals
                           join addr in _context.HospitalAddresses
                           on hosp.HospitalId equals addr.Hospitalid
                           select new HospitalDTO()
                           {
                               HospitalId = hosp.HospitalId,
                               HospitalName = hosp.HospitalName,
                               HospitalPhoneNumber = hosp.HospitalPhoneNumber,
                               StreetNumber = addr.StreetNumber,
                               Area = addr.Area,
                               City = addr.City,
                               State = addr.State,
                               Country = addr.Country,
                               ZipCode = addr.ZipCode
                           }).ToList();
            return details;
        }

        public HospitalDTO AddHospital(HospitalDTO hospitalDTO)
        {
            var hospitals = new Hospital()
            {
                HospitalName = hospitalDTO.HospitalName,
                HospitalPhoneNumber = hospitalDTO.HospitalPhoneNumber
            };
            _context.Hospitals.Add(hospitals);
            _context.SaveChanges();
            int hospitalid = hospitals.HospitalId;

            HospitalAddress addr = new HospitalAddress()
            {
                StreetNumber = hospitalDTO.StreetNumber,
                Area = hospitalDTO.Area,
                City = hospitalDTO.City,
                State = hospitalDTO.State,
                Country = hospitalDTO.Country,
                ZipCode = hospitalDTO.ZipCode,
                Hospitalid = hospitalid
            };
            _context.HospitalAddresses.Add(addr);
            _context.SaveChanges();
            hospitalDTO.HospitalId = hospitalid;
            return hospitalDTO;

        }





        public List<HospitalDTO> GetHospitalId(int id)
        {

            //hospital = _context.Hospitals.Where(o => o.HospitalId == id).Select(o => new Hospital()
            //{
            //    HospitalName = o.HospitalName,
            //    HospitalPhoneNumber = o.HospitalPhoneNumber
            //}).ToList<Hospital>();
            hospital = (from hosp in _context.Hospitals
                            join addr in _context.HospitalAddresses
                            on hosp.HospitalId equals addr.Hospitalid
                            where hosp.HospitalId == id
                            select new HospitalDTO()
                            {
                                HospitalId = hosp.HospitalId,
                                HospitalName = hosp.HospitalName,
                                HospitalPhoneNumber = hosp.HospitalPhoneNumber,
                                StreetNumber = addr.StreetNumber,
                                Area = addr.Area,
                                City = addr.City,
                                State = addr.State,
                                Country = addr.Country,
                                ZipCode = addr.ZipCode
                            }).ToList();
            return hospital;
        }
        public Hospital Delete(int id)
        {

            Hospital hospital = _context.Hospitals.Include(adr => adr.HospitalAddresses).FirstOrDefault(x => x.HospitalId == id);
            if (hospital != null)
            {
                _context.Hospitals.Remove(hospital);
                _context.SaveChanges();
            }
            return hospital;

        }
        public HospitalDTO Update(int id, Entities.HospitalDTO hospitalDTO)
        {

            var hospitals = _context.Hospitals.FirstOrDefault(e => e.HospitalId == id);
            {
                hospitals.HospitalName = hospitalDTO.HospitalName;
                hospitals.HospitalPhoneNumber = hospitalDTO.HospitalPhoneNumber;

            }
                var addr = _context.HospitalAddresses.FirstOrDefault(x => x.Hospitalid == hospitals.HospitalId);
                {
                    addr.StreetNumber = hospitalDTO.StreetNumber;
                    addr.Area = hospitalDTO.Area;
                    addr.City = hospitalDTO.City;
                    addr.State = hospitalDTO.State;
                    addr.Country = hospitalDTO.Country;
                    addr.ZipCode = hospitalDTO.ZipCode;

                }
            
            _context.SaveChanges();
            return hospitalDTO;









        }
    }
}
