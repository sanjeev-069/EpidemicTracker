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
    public class PatientController : ControllerBase
    {
        IPatientRepository pr;
        public PatientController(IPatientRepository PatientRepository)
        {
            pr = PatientRepository;
        }

        [HttpGet]
        public ActionResult<List<Patient>> GetPatientDetail()
        {

            var Patients = pr.GetPatientDetail();
            if (Patients.Count == 0)
            {
                return NotFound("No Patient Data Exist");
            }
            return Ok(Patients);

        }
        //public ActionResult<Patient> GetPatients()
        //{

        //    var Patients = pr.GetPatients();
        //    if (Patients.Count == 0)
        //    {
        //        return NotFound("No Patient Data Exist");
        //    }
        //    return Ok(Patients);

        //}



        //[HttpGet]
        //public ActionResult<Patient> GetPatientbyId(int id)
        //{
        //    var log = new List<Patient>();
        //    log = ls.GetPatientbyId(id);
        //    if (log.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(log);

        //}



        [HttpPost]
        public ActionResult<List<PatientDTO>> PostPatient(PatientDTO PatientDTO)
        {
            pr.AddPatient(PatientDTO);
            return Ok(PatientDTO.PatientId);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]Patient Patient)
        {
            if (id > 0)
            {
                pr.Update(Patient);
                return Ok("Patient Details Updated");
            }
            return NotFound();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                pr.Delete(id);
                return Ok("Patient deleted");
            }

            return NotFound("Patient not found");


        }



    }
}