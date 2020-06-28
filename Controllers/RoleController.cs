using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicTrackerApplication.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleRepository rs;
        public RoleController(IRoleRepository roleRepository)
        {
            rs = roleRepository;
        }

        [HttpGet]
        public ActionResult<Role> GetRoles()
        {
            var roles = new List<Role>();
            roles = rs.GetRoles();
            if (roles.Count == 0)
            {
                return NotFound("No Roles Exist");
            }
            return Ok(roles);

        }

        [HttpPost]
        public ActionResult Post([FromBody] Role role)
        {
            rs.Add(role);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]Role role)
        {
            if (id > 0)
            {
                rs.Update(role);
                return Ok("Role Details Updated");
            }
            return NotFound();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                rs.Delete(id);
                return Ok("Role deleted");
            }

            return NotFound("Role not found");


        }
    }
}
