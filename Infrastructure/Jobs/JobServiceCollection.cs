using Infrastructure.Settings;
using Quartz;

namespace Infrastructure.Jobs;

public static class JobServiceCollection
{
    public const string BirthdayCron = "CronExpression:PersonFindBirthdaysJob";

    public static IServiceCollection AddJobs(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddQuartz(x =>
        {
            var birthdayJobKey = new JobKey(nameof(PersonBirthdaysJob));

            x.AddJob<PersonBirthdaysJob>(opts => opts.WithIdentity(birthdayJobKey));

            var birthdayTriggerKey = new TriggerKey(nameof(PersonBirthdaysJob) + "Trigger");

            var birthdayCron = configuration.GetSection(TelegramSettings.Key).Get<CronExpressionSettings>();

            if (birthdayCron?.PersonFindBirthdaysJobCron is null)
            {
                throw new Exception("Cron was not found");
            }

            x.AddTrigger(opts => opts
                .ForJob(birthdayJobKey)
                .WithIdentity(birthdayTriggerKey)
                .WithCronSchedule("0/5 * * ? * *"));
                // .WithCronSchedule(birthdayCron.PersonFindBirthdaysJobCron));
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        return services;
    }
}