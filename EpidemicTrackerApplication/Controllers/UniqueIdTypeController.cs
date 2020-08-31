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
    [Route("api/[controller]")]
    [ApiController]
    public class UniqueIdTypeController : ControllerBase
    {
        IUniqueIdTypeRepository uid;
        public UniqueIdTypeController(IUniqueIdTypeRepository uniqueIdTypeRepository)
        {
            uid = uniqueIdTypeRepository;
        }

        [HttpGet]
        public ActionResult<UniqueIdType> GetUniqueId()
        {
            
            var id = uid.GetUniqueId();
            if (id.Count == 0)
            {
                return NotFound("No Id Exist");
            }
            return Ok(id);

        }

        [HttpPost]
        public ActionResult Post([FromBody] UniqueIdType uniqueIdType)
        {
            uid.Add(uniqueIdType);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]UniqueIdType uniqueIdType)
        {
            if (id > 0)
            {
                uid.Update(uniqueIdType);
                return Ok("Id Details Updated");
            }
            return NotFound();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                uid.Delete(id);
                return Ok("Id deleted");
            }

            return NotFound("Id not found");


        }
    }
}
