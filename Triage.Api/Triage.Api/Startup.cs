using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Middlewares;
using Models.AppSettings;
using Models.Entity;
using MongoDB;
using MongoDB.Base;
using Services;
using System;
using System.Text.Json.Serialization;

namespace Triage.Api
{
    public class Startup
    {
        private readonly IHostEnvironment _hostingEnvironment;

        public Startup(IHostEnvironment env)
        {
            _hostingEnvironment = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers().AddJsonOptions(options =>
                 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
              );
            ConfigureAppSettings(services);
            ConfigureDependencyInjection(services);
            services.AddCors(
                options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                });
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory API (" + _hostingEnvironment.EnvironmentName + ")", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureAppSettings(IServiceCollection services)
        {
            services.Configure<MongoDbSetting>(Configuration.GetSection("MongoDbSetting"));
            string mongoUri = Environment.GetEnvironmentVariable("MONGO_URI");
            if (!string.IsNullOrEmpty(mongoUri))
            {
                services.Configure<MongoDbSetting>(opt => opt.ConnectionString = mongoUri);
            }
            services.Configure<AuthSetting>(Configuration.GetSection("AuthSetting"));
        }
        public void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<MongoDBService>();
            services.AddTransient<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IPatientTriageService, PatientTriageService>();
            services.AddTransient<IEntityService<User>, EntityService<User>>();
            services.AddTransient<IEntityService<Patient>, EntityService<Patient>>();
            services.AddTransient<IEntityService<PatientTriage>, EntityService<PatientTriage>>();
        }

    }
}
