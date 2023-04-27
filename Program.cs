using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Testing {
    public class Program {
        public static void Main(string[] args) {
            Process process = new Process();
            process.StartInfo.FileName ="C:\\Program Files\\nodejs\\npm.cmd";
            process.StartInfo.Arguments = "run dev -- --port 8081";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(),"ClientApp");
            process.Start();
            CreateHostBuilder(args).Build().Run();
            process.Kill();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls("http://*:8080");
                });
    }
}