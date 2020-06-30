using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Services.Swagger;
using Swashbuckle.Swagger;

namespace Services
{
    public class Startup
    {
        private readonly string cors = "mycors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("MyConnection"), sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                })
            );

            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy(cors, builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "*")
                      .AllowAnyHeader()
                      .AllowAnyOrigin()
                      .AllowAnyMethod();
                });
            });

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = SwaggerConfiguration.DocInfoTitle,
                        Version = SwaggerConfiguration.DocInfoVersion,
                        Description = SwaggerConfiguration.DocInfoDescription,
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = SwaggerConfiguration.ContactName,
                            Url = new Uri(SwaggerConfiguration.ContactUrl)
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(cors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
