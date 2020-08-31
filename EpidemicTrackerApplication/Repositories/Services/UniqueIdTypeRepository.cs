using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class UniqueIdTypeRepository: IUniqueIdTypeRepository
    {
        private List<UniqueIdType> uniqueIdType;

        private EpidemicTrackerDbContext _context;
        public UniqueIdTypeRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<UniqueIdType> GetUniqueId()
        {
            return _context.UniqueIdTypes.ToList();

        }

        public List<UniqueIdType> GetUniqueidId(int id)
        {

            uniqueIdType = _context.UniqueIdTypes.Where(l => l.UniqueId == id).ToList();
            return uniqueIdType;
        }


        public UniqueIdType Add(UniqueIdType uniqueIdType)
        {

            _context.UniqueIdTypes.Add(uniqueIdType);
            _context.SaveChanges();


            return uniqueIdType;
        }

        public UniqueIdType Delete(int id)
        {

            UniqueIdType uniqueIdType = _context.UniqueIdTypes.Find(id);
            if (uniqueIdType != null)
            {
                _context.UniqueIdTypes.Remove(uniqueIdType);
                _context.SaveChanges();
            }
            return uniqueIdType;

        }
        public UniqueIdType Update(UniqueIdType idChanges)
        {

            var uniqueid = _context.UniqueIdTypes.Attach(idChanges);
            uniqueid.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return idChanges;



        }
    }
}

   