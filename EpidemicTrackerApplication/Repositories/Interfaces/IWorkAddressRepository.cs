using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IWorkAddressRepository
    {
        WorkAddress Add(WorkAddress address);
        WorkAddress Delete(int id);
        List<WorkAddress> GetAddress();
        List<WorkAddress> GetAddressId(int id);
        WorkAddress Update(WorkAddress addressChanges);
    }
}
