using EpidemicTrackerApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.DBContext
{
    public class EpidemicTrackerDbContext:DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<PatientAddress> PatientAddresses { get; set; }
        public DbSet<HospitalAddress> HospitalAddresses { get; set; }
        public DbSet<WorkAddress> WorkAddresses { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<UniqueIdType> UniqueIdTypes { get;set; }
        public DbSet<TreatmentDetail> TreatmentDetails { get; set; }
        public DbSet<TreatmentRecord> TreatmentRecords { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=INHYD2LABPC09;Initial Catalog=EpidemicTrackerDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(l => l.LoginId);
                entity.Property(l => l.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
                entity.Property(l => l.Gender).HasColumnName("Gender").HasMaxLength(6);
                entity.Property(l => l.Email).HasColumnName("Email").IsRequired();
                entity.HasIndex(l => l.Email).IsUnique();
                entity.Property(l => l.PhoneNumber).HasColumnName("PhoneNumber");
                entity.Property(l => l.Password).HasColumnName("Password").HasMaxLength(16).IsRequired();

                entity.HasOne<Role>(r => r.Role).WithMany(l => l.Logins).HasForeignKey(r => r.Roleid);
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);
                entity.Property(r => r.RoleName).HasColumnName("RoleName").HasMaxLength(15).IsRequired();
            });
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);
              
                entity.Property(p => p.Age).HasColumnName("Age").HasMaxLength(3).IsRequired();
                entity.Property(p => p.Gender).HasColumnName("Gender").HasMaxLength(6).IsRequired();
                entity.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
                entity.Property(p=>p.PatientName).HasColumnName("PatientName").HasColumnType("varchar(50)").HasMaxLength(100).IsRequired();

               
               // entity.HasOne<Login>(l => l.Login).WithMany(p => p.Patients).HasForeignKey(l => l.Loginid).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Login>(l => l.Login).WithMany(p => p.Patients).HasForeignKey(l => l.Loginid).OnDelete(DeleteBehavior.Cascade);

            });
            
            
            modelBuilder.Entity<UniqueIdType>(entity =>
            {
                entity.HasKey(uid => uid.UniqueId);
                entity.Property(uid=>uid.UniqueidType).HasColumnName("UniqueIdType").HasMaxLength(25).IsRequired();
                entity.Property(uid => uid.UniqueidNumber).HasColumnName("UniqueIdNumber").IsRequired();

         
               // entity.HasOne<Patient>(r => r.Patient).WithOne(l => l.UniqueIdType).HasForeignKey<UniqueIdType>(r => r.Patientid).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Patient>(r => r.Patient).WithOne(l => l.UniqueIdType).HasForeignKey<UniqueIdType>(r => r.Patientid).OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<PatientAddress>(entity =>
            {
                entity.HasKey(ad => ad.AddressId);
                entity.Property(ad => ad.StreetNumber).HasColumnName("StreetNumber").HasMaxLength(15).IsRequired();
                entity.Property(ad => ad.Area).HasColumnName("Area").HasMaxLength(30).IsRequired();               
                entity.Property(ad => ad.City).HasColumnName("City").HasMaxLength(20).IsRequired();
                entity.Property(ad => ad.State).HasColumnName("State").HasMaxLength(20).IsRequired();
                entity.Property(ad => ad.Country).HasColumnName("Country").HasMaxLength(20).IsRequired();
                entity.Property(ad => ad.ZipCode).HasColumnName("ZipCode").HasMaxLength(10).IsRequired();

               
               // entity.HasOne<Patient>(p => p.Patient).WithMany(ad => ad.PatientAddresses).HasForeignKey(p => p.Patientid).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Patient>(p => p.Patient).WithMany(ad => ad.PatientAddresses).HasForeignKey(p => p.Patientid).OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.HasKey(ocp => ocp.OccupationId);
                entity.Property(ocp => ocp.OrganisationName).HasColumnName("OrganisationName").HasMaxLength(30).IsRequired();
                entity.Property(ocp => ocp.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20).IsRequired();
                entity.Property(ocp => ocp.WorkType).HasColumnName("WorkType").HasMaxLength(20).IsRequired();
                entity.Property(ocp => ocp.Designation).HasColumnName("Designation").HasMaxLength(20).IsRequired();


                //entity.HasOne<Patient>(p => p.Patient).WithOne(ocp => ocp.Occupation).HasForeignKey<Occupation>(p => p.Patientid).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Patient>(p => p.Patient).WithOne(ocp => ocp.Occupation).HasForeignKey<Occupation>(p => p.Patientid).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<WorkAddress>(entity =>
            {
                entity.HasKey(ad => ad.AddressId);
                entity.Property(ad => ad.StreetNumber).HasColumnName("StreetNumber").HasMaxLength(15).IsRequired();
                entity.Property(ad => ad.Area).HasColumnName("Area").HasMaxLength(30).IsRequired();
                entity.Property(ad => ad.City).HasColumnName("City").HasMaxLength(20).IsRequired();
                entity.Property(ad => ad.State).HasColumnName("State").HasMaxLength(20).IsRequired();
                entity.Property(ad => ad.Country).HasColumnName("Country").HasMaxLength(20).IsRequired();
                entity.Property(ad => ad.ZipCode).HasColumnName("ZipCode").HasMaxLength(10).IsRequired();

                //entity.HasOne<Occupation>(o => o.Occupation).WithMany(ad => ad.WorkAddresses).HasForeignKey(o => o.Occupationid).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Occupation>(o => o.Occupation).WithMany(ad => ad.WorkAddresses).HasForeignKey(o => o.Occupationid).OnDelete(DeleteBehavior.Cascade);
                
            });
            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(d => d.HospitalId);
                entity.Property(d => d.HospitalName).HasColumnName("HospitalName").HasMaxLength(20).IsRequired();
                entity.Property(d => d.HospitalPhoneNumber).HasColumnName("HospitalPhoneNumber").HasMaxLength(20).IsRequired();
            });
            modelBuilder.Entity<HospitalAddress>(entity =>
            {
                entity.HasKey(ad => ad.AddressId);
                entity.Property(ad => ad.StreetNumber).HasColumnName("StreetNumber").HasMaxLength(15).IsRequired();
                entity.Property(ad => ad.Area).HasColumnName("Area").HasMaxLength(30).IsRequired();
                entity.Property(ad => ad.City).HasColumnName("City").HasMaxLength(20).IsRequired();
                entity.Property(ad => ad.State).HasColumnName("State").HasMaxLength(20).IsRequired();
                entity.Property(ad => ad.Country).HasColumnName("Country").HasMaxLength(20).IsRequired();
                entity.Property(ad => ad.ZipCode).HasColumnName("ZipCode").HasMaxLength(10).IsRequired();

               // entity.HasOne<Hospital>(h => h.Hospital).WithMany(ad => ad.HospitalAddresses).HasForeignKey(h => h.Hospitalid).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Hospital>(h => h.Hospital).WithMany(ad => ad.HospitalAddresses).HasForeignKey(h => h.Hospitalid).OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<Disease>(entity =>
            {
                entity.HasKey(d => d.DiseaseId);
                entity.Property(d => d.DiseaseName).HasColumnName("DiseaseName").HasMaxLength(20).IsRequired();
                entity.Property(d => d.DiseaseType).HasColumnName("DiseaseType").HasMaxLength(20).IsRequired();
            });

            modelBuilder.Entity<TreatmentDetail>(entity =>
            {
                entity.HasKey(td => td.TreatmentId);
                entity.Property(td => td.AdmitDate).HasColumnName("AdmitDate").HasColumnType("datetime").IsRequired();
                entity.Property(td => td.Prescription).HasColumnName("Prescription").HasMaxLength(200);
                entity.Property(td => td.RelievingDate).HasColumnName("RelievingDate").HasColumnType("datetime");
                entity.Property(td => td.IsFatality).HasColumnName("IsFatality").HasMaxLength(10);

                //entity.HasOne<Stage>(s => s.Stage).WithMany(td => td.TreatmentDetails).HasForeignKey(s => s.Stageid).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Stage>(s => s.Stage).WithMany(td => td.TreatmentDetails).HasForeignKey(s => s.Stageid).OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<Stage>(entity =>
            {
                entity.HasKey(s => s.StageId);
                entity.Property(s => s.CurrentStage).HasColumnName("CurrentStage").HasColumnType("varchar(50)").HasMaxLength(15).IsRequired();
            });
            modelBuilder.Entity<TreatmentRecord>(entity =>
            {
                entity.HasKey(r => r.RecordId);
                entity.HasOne<TreatmentDetail>(td => td.TreatmentDetails).WithMany(tr => tr.TreatmentRecords).HasForeignKey(td => td.Treatmentid).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<Disease>(d => d.Disease).WithMany(tr => tr.TreatmentRecords).HasForeignKey(d => d.Diseaseid).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<Patient>(p => p.Patient).WithMany(tr => tr.TreatmentRecords).HasForeignKey(p => p.PatientId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<Hospital>(h => h.Hospital).WithMany(tr => tr.TreatmentRecords).HasForeignKey(h => h.Hospitalid).OnDelete(DeleteBehavior.Cascade);
                //entity.HasOne<TreatmentDetail>(td => td.TreatmentDetails).WithMany(tr => tr.TreatmentRecords).HasForeignKey(td => td.Treatmentid).OnDelete(DeleteBehavior.NoAction);
                //entity.HasOne<Disease>(d => d.Disease).WithMany(tr => tr.TreatmentRecords).HasForeignKey(d => d.Diseaseid).OnDelete(DeleteBehavior.NoAction);
                //entity.HasOne<Patient>(p => p.Patient).WithMany(tr => tr.TreatmentRecords).HasForeignKey(p => p.PatientId).OnDelete(DeleteBehavior.NoAction);
                //entity.HasOne<Hospital>(h => h.Hospital).WithMany(tr => tr.TreatmentRecords).HasForeignKey(h => h.Hospitalid).OnDelete(DeleteBehavior.NoAction);
            });
            //entity.HasOne<TreatmentDetail>(td => td.TreatmentDetails).WithMany(tr => tr.TreatmentRecords).HasForeignKey(td => td.Treatmentid).OnDelete(DeleteBehavior.Restrict);
            // entity.HasOne<Disease>(d => d.Disease).WithMany(tr => tr.TreatmentRecords).HasForeignKey(d => d.Diseaseid).OnDelete(DeleteBehavior.Restrict);
              //  entity.HasOne<Patient>(p => p.Patient).WithMany(tr => tr.TreatmentRecords).HasForeignKey(p => p.PatientId).OnDelete(DeleteBehavior.Restrict);
                //entity.HasOne<Hospital>(h => h.Hospital).WithMany(tr => tr.TreatmentRecords).HasForeignKey(h => h.Hospitalid).OnDelete(DeleteBehavior.Restrict);
            //});
        }
    }
}
    