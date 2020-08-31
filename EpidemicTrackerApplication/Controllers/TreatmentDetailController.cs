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
    public class TreatmentDetailController : ControllerBase
    {
        ITreatmentDetailRepository tdr;
        public TreatmentDetailController(ITreatmentDetailRepository treatmentdetailRepository)
        {
            tdr = treatmentdetailRepository;
        }

        [HttpGet]
        public ActionResult<TreatmentDetail> GetTreatmentDetails()
        {
            
            var treatmentdetails = tdr.GetTreatmentDetails();
            if (treatmentdetails.Count == 0)
            {
                return NotFound("No Treatment Details Exist");
            }
            return Ok(treatmentdetails);

        }



        //[HttpGet]
        //public ActionResult<TreatmentDetail> GetTreatmentDetailbyId(int id)
        //{
        //    var log = new List<TreatmentDetail>();
        //    log = tdr.GetTreatmentDetailbyId(id);
        //    if (log.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(log);

        //}



        [HttpPost]
        public ActionResult<List<TreatmentDetailDTO>> Post(TreatmentDetailDTO treatmentdetailDTO)
        {
            tdr.AddTreatment(treatmentdetailDTO);
            return Ok(treatmentdetailDTO.TreatmentId);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]TreatmentDetail treatmentdetail)
        {
            if (id > 0)
            {
                tdr.Update(treatmentdetail);
                return Ok("Treatment Details Updated");
            }
            return NotFound();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                tdr.Delete(id);
                return Ok("Treatment Details deleted");
            }

            return NotFound("Treatment Details not found");


        }
    }
}