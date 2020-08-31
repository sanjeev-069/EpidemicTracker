using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class StageRepository : IStageRepository
    {
        private List<Stage> stage;

        private EpidemicTrackerDbContext _context;
        public StageRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<Stage> GetStage()
        {
            return _context.Stages.ToList();

            //login = _context.Logins.Select(l => new Login()
            //{

            //    LoginId = l.LoginId,
            //    Name = l.Name,
            //    Gender = l.Gender,
            //    Email = l.Email,
            //    PhoneNumber = l.PhoneNumber,
            //    Password = l.Password

            //}).ToList<Login>();
            //_context.SaveChanges();
            //       return login;
        }

        public List<Stage> GetStagebyId(int id)
        {

            //stage = _context.Stages.Where(s => s.StageId == id).Select(s => new Stage()
            //{
            //    CurrentStage = s.CurrentStage
            //}).ToList<Stage>();
            stage = _context.Stages.Where(s => s.StageId == id).ToList();
            return stage;
        }


        public Stage Add(Stage stage)
        {
            _context.Stages.Add(stage);
            _context.SaveChanges();
            //_context.Stages.Add(new Stage()
            //{
            //    CurrentStage = stage.CurrentStage,


            //});
            _context.SaveChanges();

            return stage;
        }

        public Stage Delete(int id)
        {

            Stage stage = _context.Stages.Find(id);
            if (stage != null)
            {
                _context.Stages.Remove(stage);
                _context.SaveChanges();
            }
            return stage;

        }
        public Stage Update(Stage stageChanges)
        {

            var stage = _context.Stages.Attach(stageChanges);
            stage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return stageChanges;



        }
    }
}
