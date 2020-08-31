using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicTrackerApplication.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginRepository ls;
        public LoginController(ILoginRepository loginRepository)
        {
            ls = loginRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LoginDTO>> GetLoginsDTO()
        {

            var logins = ls.GetLoginsDTO();
            if (logins == null)
            {
                return NotFound("No Login Data Present");
            }
            return Ok(logins);

        }

        [HttpPost]
        public ActionResult<LoginDTO> PostLogin(LoginDTO loginDTO)
        {
            ls.CreateLogin(loginDTO);
            return Ok();
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult PutLogin(int id, LoginDTO loginDTO)
        {
            if (id > 0)
            {
                ls.UpdateLogin(id, loginDTO);
                return Ok("Details Updated");
            }
            return NotFound();

        }
        [Route("{SignIn}")]
        [HttpPost]
        public ActionResult<Login> PostSignIn(Login login)
        {
            var signin = ls.SignIn(login);
            if (signin!=null)
            {
                return Ok(signin);

            }
            return NotFound("Please Enter Your Email/Password Correctly.");



        }


    }
}



//        [Route("{id}")]
//        [HttpGet]
//        public ActionResult<LoginDTO> GetLoginbyId(int id)
//        {
//            
//            var log = ls.GetLoginbyId(id);
//            if (log.Count == 0)
//            {
//                return NotFound();
//            }
//            return Ok(log);

//        }



//        [HttpPost]
//        public ActionResult Post([FromBody] LoginDTO login)
//        {
//            ls.Add(login);
//            return Ok();
//        }

//        [Route("{id}")]
//        [HttpDelete]
//        public ActionResult Delete(int id)
//        {
//            if (id > 0)
//            {
//                ls.Delete(id);
//                return Ok("Id deleted");
//            }

//            return NotFound("Id not found");


//        }
//    }
//}
