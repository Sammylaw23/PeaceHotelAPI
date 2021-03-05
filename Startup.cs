using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeaceHotelAPI.Data;
using AutoMapper;
using PeaceHotelAPI.Interfaces;
using PeaceHotelAPI.Repositories;
using PeaceHotelAPI.Helpers;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace PeaceHotelAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SwaggerOptions = new SwaggerOptions(Configuration);
        }

        public IConfiguration Configuration { get; }
        public SwaggerOptions SwaggerOptions { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(MappingConfigurations));
            services.AddControllersWithViews();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerOptions.Version, new OpenApiInfo
                {
                    Title = SwaggerOptions.Title,
                    Contact = new OpenApiContact { Email = "admin@peacehotel.com", Name = "Peace Hotel" },
                    Description = SwaggerOptions.Description,
                    Version = SwaggerOptions.Version

                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            services.AddDbContext<PeaceHotelAPIDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("AppConnectionString")));

            services.AddScoped<IClientRepo, ClientRepo>();
            services.AddScoped<IRoomRepo, RoomRepo>();
            services.AddSingleton<IEmailer, EmailerRepo>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerOptions.Endpoint, SwaggerOptions.Name);
                c.RoutePrefix = SwaggerOptions.Route;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
