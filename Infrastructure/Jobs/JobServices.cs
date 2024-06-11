using Quartz;

namespace Infrastructure.Jobs;

public static class JobServices
{
    public const string BirthdayCron = "CronExpression:PersonFindBirthdaysJob";
    
    public static IServiceCollection AddJobs(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddQuartz(x =>
        {
            var birthdayJobKey = new JobKey(nameof(PersonBirthdaysJob));

            x.AddJob<PersonBirthdaysJob>(opts => opts.WithIdentity(birthdayJobKey));

            var birthdayTriggerKey = new TriggerKey(nameof(PersonBirthdaysJob) + "Trigger");

            var birthdayCron = configuration[BirthdayCron];

            if (birthdayCron is null)
            {
                throw new Exception("Cron was not found");
            }

            x.AddTrigger(opts => opts
                .ForJob(birthdayJobKey)
                .WithIdentity(birthdayTriggerKey)
                .WithCronSchedule(birthdayCron));
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        return services;
    }
}