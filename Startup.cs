using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.StaticFiles;

namespace Testing {
    public class Startup {
      public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration {get;}

    
        public void ConfigureServices(IServiceCollection services) {
            
            services.AddControllers();
            services.AddCors(options => {
                options.AddPolicy("AllowAll",builder => {
                    builder.WithOrigins("http://localhost:8081").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "/ClientApp/dist";
            }); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseCors("AllowAll");
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
            app.Use(async (context,next) => {
    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
    await next();
                });
            app.UseStaticFiles();
            app.UseSpa(spa => {
                spa.Options.SourcePath = "ClientApp";
                if(env.IsDevelopment()) {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8081");
                }
            });
        }
    }
}