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
    public class DiseaseController : ControllerBase
    {
        IDiseaseRepository dr;

        
        public DiseaseController(IDiseaseRepository diseaseRepository)
        {
            dr = diseaseRepository;
        }

        [HttpGet]
        public ActionResult<Disease> GetDisease()
        {
            var diseases = new List<Disease>();
            diseases = dr.GetDisease();
            if (diseases.Count == 0)
            {
                return NotFound("No Disease Exist");
            }
            return Ok(diseases);

        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Disease> GetDiseasebyId(int id)
        {
            var log = new List<Disease>();
            log = dr.GetDiseaseId(id);
            if (log.Count == 0)
            {
                return NotFound();
            }
            return Ok(log);

        }

        [HttpPost]
        public ActionResult<List<DiseaseDTO>> Post(DiseaseDTO diseaseDTO)
        {
            dr.AddDisease(diseaseDTO);
            return Ok(diseaseDTO.Diseaseid);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]Disease disease)
        {
            if (id > 0)
            {
                dr.Update(disease);
                return Ok("Disease details Updated");
            }
            return NotFound();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                dr.Delete(id);
                return Ok("Disease deleted");
            }

            return NotFound("Disease not found");


        }
    }
}
