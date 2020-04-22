using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using school_backend.Context;
using school_backend.Repository;

namespace school_backend 
{
    public class Startup 
    {
        public Startup (IConfiguration _config) 
        {
            Configuration = _config;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices (IServiceCollection services) {

            services.AddScoped<UnitOfWork, UnitOfWork> ();
            services.AddDbContext<DatabaseContext> (options => options.UseMySql (Configuration.GetConnectionString ("DefaultConnection")));

            services.AddCors ();
            services.AddControllers ().AddNewtonsoftJson (options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            // app.UseHttpsRedirection();
            app.UseRouting ();
            // app.UseAuthorization();
            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}