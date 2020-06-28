using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class RoleRepository : IRoleRepository
    {
        private List<Role> role;

        private EpidemicTrackerDbContext _context;
        public RoleRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();

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

        public List<Role> GetRolebyId(int id)
        {

            //role = _context.Roles.Where(l => l.RoleId == id).Select(l => new Role()
            //{
            //    RoleName = l.RoleName
            //}).ToList<Role>();
            role = _context.Roles.Where(l => l.RoleId == id).ToList();
            return role;
        }


        public Role Add(Role role)
        {

            _context.Roles.Add(role);
            _context.SaveChanges();


            return role;
        }

        public Role Delete(int id)
        {

            Role role = _context.Roles.Find(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
            return role;

        }
        public Role Update(Role roleChanges)
        {

            var role = _context.Roles.Attach(roleChanges);
            role.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return roleChanges;



        }
    }
}
