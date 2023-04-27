using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Testing {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "/ClientApp/dist";
            }); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseStaticFiles();
            app.UseSpa(spa => {
                spa.Options.SourcePath = "ClientApp";
                if(env.IsDevelopment()) {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
                }
            });
        }
    }
}