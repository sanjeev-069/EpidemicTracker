using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IUniqueIdTypeRepository
    {
        List<UniqueIdType> GetUniqueId();
        List<UniqueIdType> GetUniqueidId(int id);
        UniqueIdType Add(UniqueIdType uniqueIdType);
        UniqueIdType Delete(int id);
        UniqueIdType Update(UniqueIdType idChanges);

    }
}
