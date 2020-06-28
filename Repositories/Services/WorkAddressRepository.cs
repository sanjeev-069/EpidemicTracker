using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class WorkAddressRepository : IWorkAddressRepository
    {
        private List<WorkAddress> address;

        private EpidemicTrackerDbContext _context;
        public WorkAddressRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<WorkAddress> GetAddress()
        {
            return _context.WorkAddresses.ToList();

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

        public List<WorkAddress> GetAddressId(int id)
        {

            //address = _context.WorkAddresses.Where(a => a.AddressId == id).Select(a => new WorkAddress()
            //{
            //    StreetNumber = a.StreetNumber,
            //    Area = a.Area,
            //    Locality = a.Locality,
            //    City = a.City,
            //    State = a.State,
            //    Country = a.Country,
            //    ZipCode = a.ZipCode
            //}).ToList<WorkAddress>();
            address = _context.WorkAddresses.Where(a => a.AddressId == id).ToList();
            return address;
        }


        public WorkAddress Add(WorkAddress address)
        {
            _context.WorkAddresses.Add(address);
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

        public WorkAddress Delete(int id)
        {

            WorkAddress address = _context.WorkAddresses.Find(id);
            if (address != null)
            {
                _context.WorkAddresses.Remove(address);
                _context.SaveChanges();
            }
            return address;

        }
        public WorkAddress Update(WorkAddress addressChanges)
        {

            var address = _context.WorkAddresses.Attach(addressChanges);
            address.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return addressChanges;



        }
    }
}

