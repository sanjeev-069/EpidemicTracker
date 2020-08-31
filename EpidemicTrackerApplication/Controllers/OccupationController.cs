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
    [Route("[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        IOccupationRepository or;
        public OccupationController(IOccupationRepository occupationRepository)
        {
            or = occupationRepository;
        }

        [HttpGet]
        public ActionResult<Occupation> GetOccupation()
        {
            var occupations = new List<Occupation>();
            occupations = or.GetOccupation();
            if (occupations.Count == 0)
            {
                return NotFound("No Occupation Exist");
            }
            return Ok(occupations);

        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Occupation> GetOccupationbyId(int id)
        {
            var log = new List<Occupation>();
            log = or.GetOccupationId(id);
            if (log.Count == 0)
            {
                return NotFound();
            }
            return Ok(log);

        }

        [HttpPost]
        public ActionResult<List<OccupationDTO>> PostOccupation(OccupationDTO occupationDTO)
        {
            or.AddOccupation(occupationDTO);
            return Ok();
        }
        
        
        [Route("{id}")]
        [HttpPut]
        public ActionResult Put(int id, [FromBody]Occupation occupation)
        {
            if (id > 0)
            {
                or.Update(occupation);
                return Ok("Occupation Details Updated");
            }
            return NotFound();

        }
        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                or.Delete(id);
                return Ok("Occupation deleted");
            }

            return NotFound("Occupation not found");


        }
    }
}