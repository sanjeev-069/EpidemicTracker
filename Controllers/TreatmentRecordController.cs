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
    public class TreatmentRecordController : ControllerBase
    {
        ITreatmentRecordRepository tdr;
        public TreatmentRecordController(ITreatmentRecordRepository treatmentRecordRepository)
        {
            tdr = treatmentRecordRepository;
        }

        [HttpGet]
        public ActionResult<TreatmentRecord> GetTreatmentRecords()
        {
            
            var treatmentRecords = tdr.GetTreatmentRecords();
            if (treatmentRecords.Count == 0)
            {
                return NotFound("No Treatment Records Exist");
            }
            return Ok(treatmentRecords);

        }
        [Route("{Details}")]
        [HttpGet]
        public ActionResult<TreatmentRecord> GetTreatmentRecordsDetail()
        {

            var treatmentRecords = tdr.GetTreatmentRecordsDetail();
            if (treatmentRecords.Count == 0)
            {
                return NotFound("No Dead Patient");
            }
            return Ok(treatmentRecords);

        }
        [Route("{Details}/{Cured}")]
        [HttpGet]
        public ActionResult<TreatmentRecordDTO> GetCuredDetails()
        {

            var treatmentRecords = tdr.GetCuredDetails();
            if (treatmentRecords.Count == 0)
            {
                return NotFound("No Cured Patient");
            }
            return Ok(treatmentRecords);

        }
        [Route("{Details}/{Cured}/{Uncured}")]
        [HttpGet]
        public ActionResult<TreatmentRecordDTO> GetUncuredDetails()
        {

            var treatmentRecords = tdr.GetUncuredDetails();
            if (treatmentRecords.Count == 0)
            {
                return NotFound("No Cured Patient");
            }
            return Ok(treatmentRecords);

        }



        //[HttpGet]
        //public ActionResult<TreatmentRecord> GetTreatmentRecordbyId(int id)
        //{
        //    var log = new List<TreatmentRecord>();
        //    log = tdr.GetTreatmentRecordbyId(id);
        //    if (log.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(log);

        //}



        [HttpPost]
        public ActionResult<TreatmentRecordDTO> Post(TreatmentRecordDTO treatmentRecordDTO)
        {
            tdr.AddTreatmentRecord(treatmentRecordDTO);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]TreatmentRecord treatmentRecord)
        {
            if (id > 0)
            {
                tdr.Update(treatmentRecord);
                return Ok("Treatment Records Updated");
            }
            return NotFound();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                tdr.Delete(id);
                return Ok("Treatment Records deleted");
            }

            return NotFound("Treatment Records not found");


        }
    }
}
