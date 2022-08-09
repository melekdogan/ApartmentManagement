using Business.Abstract;
using Business.Abstract.Auth;
using Business.Concrete;
using Business.Concrete.Auth;
using BusinessLayer.Configuration.Mapper;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.DBContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using BackgroundJobs.Abstract;
using BackgroundJobs.Concrete.HangFire;
using BackgroundJobs.Concrete;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)// Uygulama ayaða kalkýncaya kadar çalýþýr. 
        {

            services.AddControllers();

            #region Add Database Context
            services.AddDbContext<ApartmentManagementDBContext>(ServiceLifetime.Transient);
            #endregion

            #region  Services (Business Layer)
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceTypeService, InvoiceTypeService>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IJob, HangFireJobs>();
            services.AddScoped<ISendMailService, SendMailService>();
            #endregion

            #region Repositories (DataAccess Layer)
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceTypeRepository, InvoiceTypeRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            #endregion

            #region Auto Mapper Implementation
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            #endregion

            #region HangFire Implementation

            services.AddHangfire(configuration => configuration
         .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
         .UseSimpleAssemblyNameTypeSerializer()
         .UseRecommendedSerializerSettings()
         .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
         {
             CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
             SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
             QueuePollInterval = TimeSpan.Zero,
             UseRecommendedIsolationLevel = true,
             DisableGlobalLocks = true
         }));

            services.AddHangfireServer();
            services.AddMvc();

            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//Uygulama ayaða kalktýktan, yani çalýþtýktan sonra devreye giren konfigürasyonlardýr.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            
            app.UseHangfireDashboard("/hangfire", new DashboardOptions());
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
