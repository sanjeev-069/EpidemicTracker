using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTrackerApplication.DBContext;
using EpidemicTrackerApplication.Repositories.Interfaces;
using EpidemicTrackerApplication.Repositories.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EpidemicTrackerApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string _specificOrigin = "_specificOrigin";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            
            services.AddScoped<IPatientAddressRepository, PatientAddressRepository>();
            services.AddScoped<IHospitalAddressRepository, HospitalAddressRepository>();
            services.AddScoped<IWorkAddressRepository, WorkAddressRepository>();
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IStageRepository, StageRepository>();
            services.AddScoped<ITreatmentDetailRepository, TreatmentDetailRepository>();
            services.AddScoped<ITreatmentRecordRepository, TreatmentRecordRepository>();
            services.AddTransient<EpidemicTrackerDbContext>();
            
            services.AddCors(o =>
            {
                o.AddPolicy("_specificOrigin",
                    p => p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors(_specificOrigin);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}