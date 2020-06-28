using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Role Add(Role role);
        Role Delete(int id);
        List<Role> GetRolebyId(int id);
        List<Role> GetRoles();
        Role Update(Role roleChanges);
    }
}
