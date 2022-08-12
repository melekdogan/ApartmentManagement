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
using Business.Configuration.Cache;
using StackExchange.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            #region Redis Implementation  DÜZENLENECEK 
            var redisConfigInfo = Configuration.GetSection("RedisEndpointInfo").Get<RedisEndpointInfo>();

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.ConfigurationOptions = new ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { redisConfigInfo.EndPoint, redisConfigInfo.Port }
                    },
                    Password = redisConfigInfo.Password,
                    User = redisConfigInfo.UserName

                };
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

            #region TOKEN Options

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<Business.Configuration.Auth.TokenOption>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                    };
                });



            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
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

            #region Hangfire Dashboard 
            app.UseHangfireDashboard("/hangfire", new DashboardOptions());
            #endregion

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();//TokenOptions ile JwtBearer eklediysen bunu da eklemeyi unutma. Yoksa ConfigureServices içindeki token ayarlarý devreye girmez ve Yetkilendirme hatasý alýrsýn!!
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
