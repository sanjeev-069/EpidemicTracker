using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EpidemicTrackerApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HospitalAddressController : ControllerBase
    {
        readonly IHospitalAddressRepository ar;
        public HospitalAddressController(IHospitalAddressRepository addressRepository)
        {
            ar = addressRepository;
        }

        [HttpGet]
        public ActionResult<HospitalAddress> GetAddresses()
        {
            var addr = new List<HospitalAddress>();
            addr = ar.GetAddress();
            {
                if (addr.Count == 0)
                    return NotFound("No Hospital Address Exist");
            }
            return Ok(addr);

        }


        [Route("{id}")]
        [HttpGet]
        public ActionResult<HospitalAddress> GetHospitalAddressbyId(int id)
        {
            var log = new List<HospitalAddress>();
            log = ar.GetAddressId(id);
            if (log.Count == 0)
            {
                return NotFound();
            }
            return Ok(log);

        }



        [HttpPost]
        public ActionResult Post([FromBody] HospitalAddress address)
        {
            ar.Add(address);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]HospitalAddress address)
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
