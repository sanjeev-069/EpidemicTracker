using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        LoginDTO CreateLogin(LoginDTO loginDTO);

        LoginDTO UpdateLogin(int id, LoginDTO loginDTO);
        //Login Add(Login login);
        //Login Delete(int id);
        //List<Login> GetLoginbyId(int id);
        //List<Login> GetLogins();
        //Login Update(Login loginChanges);
        IEnumerable<LoginDTO> GetLoginsDTO();
        Login SignIn(Login login);
    }
}
