using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class LoginRepository : ILoginRepository
    {

        private EpidemicTrackerDbContext _context;
        public LoginRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        //private List<Login> login;
        private static LoginDTO DTO(Login login) => new LoginDTO
        {
            LoginId = login.LoginId,
            Name = login.Name,
            Gender = login.Gender,
            Email = login.Email,
            PhoneNumber = login.PhoneNumber,
            Password = login.Password,
            Roleid = login.Roleid
            
            
        };


        public IEnumerable<LoginDTO> GetLoginsDTO()
        {
            return _context.Logins.Select(x => DTO(x)).ToList();
        }

        [HttpPost]
        public LoginDTO CreateLogin(LoginDTO loginDTO)
        {
            var login = new Login
            {

                Name = loginDTO.Name,
                Gender = loginDTO.Gender,
                Email = loginDTO.Email,
                PhoneNumber = loginDTO.PhoneNumber,
                Password = loginDTO.Password,
                Roleid = loginDTO.Roleid
            };

            _context.Logins.Add(login);
            _context.SaveChangesAsync();

            int loginid = login.LoginId;

            return
               loginDTO;
        }
        public LoginDTO UpdateLogin(int id, LoginDTO loginDTO)
        {

            var login = _context.Logins.Where(l => l.LoginId == id).FirstOrDefault();
            {
                login.Name = loginDTO.Name;
                login.Gender = loginDTO.Gender;
                login.Email = loginDTO.Email;
                login.PhoneNumber = loginDTO.PhoneNumber;
                login.Password = loginDTO.Password;
                login.Roleid = loginDTO.Roleid;

            }
            _context.SaveChangesAsync();
            return loginDTO;
        }

        public Login SignIn(Login login)
        {
            var obj = _context.Logins.Where(e => e.Email == login.Email && e.Password == login.Password).FirstOrDefault();
            if (obj != null)
            {
               
                return obj;
                
            }

            return null;
            
        }
    }

}
