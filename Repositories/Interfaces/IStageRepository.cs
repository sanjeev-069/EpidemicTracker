using EpidemicTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Interfaces
{
    public interface IStageRepository
    {
        Stage Add(Stage stage);
        Stage Delete(int id);
        List<Stage> GetStage();
        List<Stage> GetStagebyId(int id);
        Stage Update(Stage stageChanges);
    }
}
