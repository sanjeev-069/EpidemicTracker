using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class HospitalController : ControllerBase
    {
        readonly IHospitalRepository hr;
        public HospitalController(IHospitalRepository hospitalRepository)
        {
            hr = hospitalRepository;
        }

        [HttpGet]
        public ActionResult<HospitalDTO> GetHospital()
        {
            var hospitals = hr.GetHospitalDetail();
            if (hospitals == null)
            {
                return NotFound("No Hospital Exist");
            }
            return Ok(hospitals) ;

        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<HospitalDTO> GetHospitalbyId(int id)
        {
            
            var log = hr.GetHospitalId(id);
            if (log.Count == 0)
            {
                return NotFound();
            }
            return Ok(log);

        }

        [HttpPost]
        public ActionResult<List<HospitalDTO>> PostHospital(HospitalDTO hospitalDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            hr.AddHospital(hospitalDTO);
            return Ok(hospitalDTO.HospitalId);
        }


        [HttpPut]
       [Route("{id}")]
        public ActionResult Put(int id, HospitalDTO hospitalDTO)
        {
            if (id > 0)
            {
                hr.Update(id, hospitalDTO);
                return Ok("Hospital Details Updated");
            }
            return NotFound("Hospital with Id " + id.ToString() + " not found to update");

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                hr.Delete(id);
                return Ok("Hospital Id deleted");
            }

            return NotFound("Hospital not found");


        }
    }
}