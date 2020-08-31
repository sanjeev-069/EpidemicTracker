using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class HospitalAddressRepository : IHospitalAddressRepository
    {
        private List<HospitalAddress> address;

        private EpidemicTrackerDbContext _context;
        public HospitalAddressRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<HospitalAddress> GetAddress()
        {
            return _context.HospitalAddresses.ToList();

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

        public List<HospitalAddress> GetAddressId(int id)
        {

            //address = _context.HospitalAddresses.Where(a => a.AddressId == id).Select(a => new HospitalAddress()
            //{
            //    StreetNumber = a.StreetNumber,
            //    Area = a.Area,
            //    Locality = a.Locality,
            //    City = a.City,
            //    State = a.State,
            //    Country = a.Country,
            //    ZipCode = a.ZipCode
            //}).ToList<HospitalAddress>();
            address = _context.HospitalAddresses.Where(a => a.AddressId == id).ToList();
            return address;
        }


        public HospitalAddress Add(HospitalAddress address)
        {
            _context.HospitalAddresses.Add(address);
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

        public HospitalAddress Delete(int id)
        {

            HospitalAddress address = _context.HospitalAddresses.Find(id);
            if (address != null)
            {
                _context.HospitalAddresses.Remove(address);
                _context.SaveChanges();
            }
            return address;

        }
        public HospitalAddress Update(HospitalAddress addressChanges)
        {

            var address = _context.HospitalAddresses.Attach(addressChanges);
            address.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return addressChanges;



        }
    }
}
