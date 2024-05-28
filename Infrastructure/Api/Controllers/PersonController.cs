using Application.Persons.Commands.CreatePerson;
using Application.Persons.Queries.GetPerson;
using Application.Persons.Queries.GetPersons;
using Infrastructure.Api.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api.Controllers;

[Route("api/[controller]")]
public class PersonController(ISender sender) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonRequest request)
    {
        var command = new CreatePersonCommand(request.FirstName, request.LastName, 
            request.MiddleName, request.BirthDay, request.Gender, request.PhoneNumber, request.Telegram);

        var result = await sender.Send(command);

        return result.Match(
            _ => Ok(result.Value),
            _ => Problem(result.Errors));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Read(Guid id)
    {
        var query = new GetPersonQuery(id);

        var result = await sender.Send(query);

        return result.Match(
            _ => Ok(result.Value),
            _ => Problem(result.Errors));
    }

    [HttpGet("{limit:int}")]
    public async Task<IActionResult> Read(int limit)
    {
        var query = new GetPersonsQuery(limit);

        var result = await sender.Send(query);

        return result.Match(
            _ => Ok(result.Value),
            _ => Problem(result.Errors));
    }
}