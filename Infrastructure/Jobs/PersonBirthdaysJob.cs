using Application.Persons.Queries.GetPersonsWhoseBirthday;
using MediatR;
using Quartz;

namespace Infrastructure.Jobs;

public class PersonBirthdaysJob(ISender sender) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var query = new GetPersonsWhoseBirthdayQuery(DateTime.UtcNow);
        
        var persons = await sender.Send(query);

        // отправлять отсюда
    }
}