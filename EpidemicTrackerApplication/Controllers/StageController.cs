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
    [Route("[Controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        IStageRepository sr;
        public StageController(IStageRepository stageRepository)
        {
            sr = stageRepository;
        }

        [HttpGet]
        public ActionResult<Stage> GetStages()
        {
            var stages = new List<Stage>();
            stages = sr.GetStage();
            if (stages.Count == 0)
            {
                return NotFound("No Stage Exist");
            }
            return Ok(stages);

        }

        [HttpPost]
        public ActionResult Post([FromBody] Stage stage)
        {
            sr.Add(stage);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]Stage stage)
        {
            if (id > 0)
            {
                sr.Update(stage);
                return Ok("Stage Details Updated");
            }
            return NotFound();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                sr.Delete(id);
                return Ok("Stage deleted");
            }

            return NotFound("Stage not found");


        }
    }
}