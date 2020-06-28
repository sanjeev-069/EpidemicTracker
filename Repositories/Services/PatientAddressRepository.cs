using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class PatientAddressRepository : IPatientAddressRepository
    {
        private List<PatientAddress> address;

        private EpidemicTrackerDbContext _context;
        public PatientAddressRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<PatientAddress> GetAddress()
        {
            return _context.PatientAddresses.ToList();

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

        public List<PatientAddress> GetAddressId(int id)
        {

            //address = _context.PatientAddresses.Where(a => a.AddressId == id).Select(a => new PatientAddress()
            //{
            //    StreetNumber = a.StreetNumber,
            //    Area = a.Area,
            //    Locality = a.Locality,
            //    City = a.City,
            //    State = a.State,
            //    Country = a.Country,
            //    ZipCode = a.ZipCode
            //}).ToList<PatientAddress>();
            address = _context.PatientAddresses.Where(a => a.AddressId == id).ToList();
            return address;
        }


        public PatientAddress Add(PatientAddress address)
        {
            _context.PatientAddresses.Add(address);
            _context.SaveChanges();


            //_context.Addresses.Add(new Address()
            //{
            //    StreetNumber = address.StreetNumber,
            //    Area = address.Area,
            //    Locality = address.Locality,
            //    City = address.City,
            //    State = address.State,
            //    Country = address.Country,
            //    ZipCode = address.ZipCode
            //});
            //_context.SaveChanges();

            return address;
        }

        public PatientAddress Delete(int id)
        {

            PatientAddress address = _context.PatientAddresses.Find(id);
            if (address != null)
            {
                _context.PatientAddresses.Remove(address);
                _context.SaveChanges();
            }
            return address;

        }
        public PatientAddress Update(PatientAddress addressChanges)
        {

            var address = _context.PatientAddresses.Attach(addressChanges);
            address.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return addressChanges;



        }
    }
}
