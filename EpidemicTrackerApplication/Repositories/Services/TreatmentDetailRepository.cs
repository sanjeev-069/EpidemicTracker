using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Repositories.Services
{
    public class TreatmentDetailRepository : ITreatmentDetailRepository
    {
        private List<TreatmentDetail> treatmentDetail;

        private EpidemicTrackerDbContext _context;
        public TreatmentDetailRepository(EpidemicTrackerDbContext context)
        {
            _context = context;
        }
        public List<TreatmentDetail> GetTreatmentDetails()
        {
            return _context.TreatmentDetails.ToList();

            //treatmentDetail = _context.TreatmentDetails.Select(l => new TreatmentDetail()
            //{

            //    TreatmentDetailId = l.TreatmentDetailId,
            //    Name = l.Name,
            //    Gender = l.Gender,
            //    Email = l.Email,
            //    PhoneNumber = l.PhoneNumber,
            //    Password = l.Password

            //}).ToList<TreatmentDetail>();
            //_context.SaveChanges();
            //       return treatmentDetail;
        }

        public List<TreatmentDetail> GetTreatmentDetailbyId(int id)
        {

            //treatmentDetail = _context.TreatmentDetails.Where(l => l.TreatmentId == id).Select(l => new TreatmentDetail()
            //{
            //    AdmitDate = l.AdmitDate,
            //    Prescription = l.Prescription,
            //    RelievingDate = l.RelievingDate,
            //    IsFatality = l.IsFatality

            //}).ToList<TreatmentDetail>();

            treatmentDetail = _context.TreatmentDetails.Where(l => l.TreatmentId == id).ToList();
            return treatmentDetail;

        }



        public TreatmentDetailDTO AddTreatment(TreatmentDetailDTO TreatmentDetailDTO)
        {
            var treatments = new TreatmentDetail()
            {
                AdmitDate = TreatmentDetailDTO.AdmitDate,
                Prescription = TreatmentDetailDTO.Prescription,
                RelievingDate = TreatmentDetailDTO.RelievingDate,
                IsFatality = TreatmentDetailDTO.IsFatality,
                Stageid = TreatmentDetailDTO.Stageid
            };
            _context.TreatmentDetails.Add(treatments);
            _context.SaveChanges();
            int treatmentid = treatments.TreatmentId;
            TreatmentDetailDTO.TreatmentId = treatmentid;

            return TreatmentDetailDTO;
        }

        public TreatmentDetail Delete(int id)
        {

            TreatmentDetail treatmentDetail = _context.TreatmentDetails.Find(id);
            if (treatmentDetail != null)
            {
                _context.TreatmentDetails.Remove(treatmentDetail);
                _context.SaveChanges();
            }
            return treatmentDetail;

        }
        public TreatmentDetail Update(TreatmentDetail treatmentDetailChanges)
        {

            var treatmentDetail = _context.TreatmentDetails.Attach(treatmentDetailChanges);
            treatmentDetail.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return treatmentDetailChanges;

        }

    }
}