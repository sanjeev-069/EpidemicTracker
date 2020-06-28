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
    [Route("[controller]")]
    [ApiController]
    public class WorkAddressController : ControllerBase
    {
        IWorkAddressRepository ar;
        public WorkAddressController(IWorkAddressRepository addressRepository)
        {
            ar = addressRepository;
        }

        [HttpGet]
        public ActionResult<WorkAddress> GetAddresses()
        {
            var addr = new List<WorkAddress>();
            addr = ar.GetAddress();
            {
                if (addr.Count == 0)
                    return NotFound("No Work Address Exist");
            }
            return Ok(addr);

        }



        //[HttpGet]
        //public ActionResult<Login> GetLoginbyId(int id)
        //{
        //    var log = new List<Login>();
        //    log = ls.GetLoginbyId(id);
        //    if (log.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(log);

        //}



        [HttpPost]
        public ActionResult Post([FromBody] WorkAddress address)
        {
            ar.Add(address);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]WorkAddress address)
        {
            if (id > 0)
            {
                ar.Update(address);
                return Ok("Address Updated");
            }
            return NotFound();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                ar.Delete(id);
                return Ok("Address deleted");
            }

            return NotFound("Address not found");


        }
    }
}

