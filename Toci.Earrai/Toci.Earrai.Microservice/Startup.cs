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
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Toci.Common.Database.Interfaces;

using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Interfaces;
using IWorksheetLogic = Toci.Earrai.Bll.Interfaces.IWorksheetLogic;
using Toci.Earrai.Bll.Warehouse;
using Toci.Earrai.Bll.Warehouse.Interfaces;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Erp;
using Toci.Common;
using Toci.Earrai.Bll.ErrorLog;
using Toci.Earrai.Bll.SageIntegration;

namespace Toci.Earrai.Microservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AuthenticationSettings authenticationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            GlobalExceptionHandler Geh = new GlobalExceptionHandler(new EarraiErrorLogger());
            Geh.ActivateGlobalExceptionHandling();

            services.AddScoped<IWorksheetLogic, WorksheetLogic>();
            services.AddScoped<IWorksheetcontentLogic, WorksheetcontentLogic>();
            services.AddScoped<IEntityOperations, EntityOperations>();
            services.AddScoped<IAreaquantityLogic, AreaquantityLogic>();
            services.AddScoped<IAreasquantitiesLogic, AreasquantitiesLogic>();
            services.AddScoped<IAreasLogic, AreasLogic>();
            services.AddScoped<IQuoteandpriceLogic, QuoteandpriceLogic>();
            services.AddScoped<IProductLogic, ProductLogic>();
            services.AddScoped<IProductSizeLogic, ProductSizeLogic>();
            services.AddScoped<IQuoteAndMetricLogic, QuoteAndMetricLogic>();
            services.AddScoped<IPrivilegesLogic, PrivilegesLogic>();
            services.AddScoped<ISageLogic, SageExportLogic>();
            services.AddScoped<ISynchroLogic, SynchroLogic>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();

            services.AddSingleton(authenticationSettings);

            services.AddResponseCompression();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
                };
            });

            services.AddControllers();
            //services.AddCors(x => x.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())); //na localhoscie
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Toci.Earrai.Microservice", Version = "v1" });
            });

            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IEntityOperations, EntityOperations>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Toci.Earrai.Microservice v1"));
            }

            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // localhost

            app.UseAuthentication();
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
