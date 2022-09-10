using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using RisetQuartzProject.Core;
using RisetQuartzProject.Startup;
using SampleBLL;
using Serilog;

namespace RisetQuartzProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                        .AddEnvironmentVariables()
                                        .AddCommandLine(args)
                                        .Build();

            var builder = Host.CreateDefaultBuilder()
                                .UseSerilog((context, configuration) =>
                                {
                                    configuration
                                        .MinimumLevel.Verbose()
                                        .Enrich.FromLogContext()
                                        .Enrich.WithMachineName()
                                        .WriteTo.Debug()
                                        .WriteTo.Console()
                                        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                                        .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                                        .ReadFrom.Configuration(context.Configuration);
                                })
                                .ConfigureServices((context, services) =>
                                {
                                    services.AddSingleton<IJobFactory, JobFactory>();
                                    services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
                                    services.AddHostedService<QuartzHostedService>();
                                    services.AddSingleton<QuartzJobRunner>();

                                    services.AddSingleton<IUnitOfWork, UnitOfWork>();
                                    services.AddSingleton<EODService>();

                                    services.AddJobs(configuration);
                                });

            var app = builder.Build();

            app.Run();
        }
    }
}

