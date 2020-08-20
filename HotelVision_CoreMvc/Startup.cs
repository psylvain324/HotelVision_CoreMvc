using System.IO;
using System.Reflection;
using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using HotelVision_CoreMvc.Data;
using HotelVision_CoreMvc.Models;
using HotelVision_CoreMvc.Services;
using HotelVision_CoreMvc.Services.Interfaces;
using System;
using HotelVision_CoreMvc.Repositories;

namespace HotelVision_CoreMvc
{
    public class Startup
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void ConfigureServices(IServiceCollection services)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddControllers();
            services.AddMvc();

            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson();
            services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(databaseName: "TechnicalAssessmentDb"));
            services.AddScoped<IServiceUpload<Customer>, CustomerUploadService>();
            services.AddScoped<IServiceUpload<Transaction>, TransactionUploadService>();
            services.AddScoped<IServiceExport<Transaction>, TransactionExportService>();
            services.AddTransient<SqlInventoryRepository, SqlInventoryRepository>();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext databaseContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMvc();
            app.UseStaticFiles(new StaticFileOptions() { FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")) });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DataGenerator.Initialize(databaseContext);

        }
    }
}
