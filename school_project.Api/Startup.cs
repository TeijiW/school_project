using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using school_project.Infra.Context;
using school_project.Infra.Repository;

namespace school_project 
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
            services.AddDbContext<DatabaseContext>();
            services.AddCors ();
            services.AddControllers();
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