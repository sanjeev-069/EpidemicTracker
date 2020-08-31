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



        [HttpPost]
        public ActionResult<List<PatientDTO>> PostPatient(PatientDTO PatientDTO)
        {
            pr.AddPatient(PatientDTO);
            return Ok(PatientDTO.PatientId);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(int id, TreatmentRecordDTO treatmentRecordDTO)
        {
            if (id > 0)
            {
                pr.Update(id, treatmentRecordDTO);
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