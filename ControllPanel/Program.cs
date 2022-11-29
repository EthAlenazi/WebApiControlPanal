using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                path: "C:\\Serilog_ControlPanal\\logs\\log-.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day,//Created Separate file for every day
                restrictedToMinimumLevel: LogEventLevel.Information//Means this file for the track the general flow of the application.

                ).CreateLogger();
            try
            {
                Log.Information("Application is Starting Running");
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {

                Log.Fatal(ex,"Application Fiild to Start");
            }
            finally
            {
                Log.CloseAndFlush();
            }

           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
