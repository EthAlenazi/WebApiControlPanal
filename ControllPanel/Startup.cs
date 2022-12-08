using AutoMapper;
using ControllPanel.Configurations;
using ControllPanel.Data;
using ControllPanel.IRepository;
using ControllPanel.Repository;
using ControllPanel.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel
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

            services.AddDbContext<DatabaseContext>(opation =>
            opation.UseSqlServer(Configuration.GetConnectionString("SqlConnaction"))
            );
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);
            
            //CORS= Cross Origin Resource Sharing 
            services.AddCors(o => {
                o.AddPolicy("corsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddAutoMapper(typeof(MapperInitilizer));
            services.AddTransient<IUnitofWork, UnitofWork>();//
            services.AddScoped<IAuthManager, AuthManager>();//What's the difference between them
            AddSwaggerDoc(services);

            services.AddControllers().AddNewtonsoftJson(op =>
            op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        private void AddSwaggerDoc(IServiceCollection services) {

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {Description= @"Enter 'Bearer' [space] and then enter yourtoken in the text 
                                input below. For Examble:
                                 Bearer 123456", 
                Name="Authorization",
                In=ParameterLocation.Header,
                Type=SecuritySchemeType.ApiKey,
                Scheme="Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    { new OpenApiSecurityScheme
                     {
                         Reference = new OpenApiReference
                         {
                             Type= ReferenceType.SecurityScheme,
                             Id= "Bearer"
                         },
                         Scheme = "0auth2",
                         Name ="Bearer",
                         In = ParameterLocation.Header
                     },
                     new List<string>()
                     }
                });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControllPanel",
                    Version = "v1", 
                    Description = "This is for the purpose of learning" });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControllPanel v1"));
            app.UseHttpsRedirection();


            app.UseCors("corsPolicy");//Allow Anyone to use our resource even when they not in same domain

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
             
                endpoints.MapControllers();
            });
        }
    }
}
