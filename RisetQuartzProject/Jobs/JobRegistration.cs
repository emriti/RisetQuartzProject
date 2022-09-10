using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RisetQuartzProject.Core;
using RisetQuartzProject.Jobs;

namespace RisetQuartzProject.Startup
{
    public static class JobRegistration
    {
        public static void AddJobs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MTMJob>();
            services.AddSingleton(new JobSchedule(
                        jobType: typeof(MTMJob),
                        cronExpression: configuration.GetValue<string>("MTM:CronSchedule"))
                    );

            services.AddScoped<PrintGuidJob>();
            services.AddSingleton(new JobSchedule(
                        jobType: typeof(PrintGuidJob),
                        cronExpression: configuration.GetValue<string>("MTM:CronSchedule"))
                    );
        }
    }
}
