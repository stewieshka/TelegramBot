using Application.Persons.Commands.AddCustomField;
using Application.Persons.Commands.CreatePerson;
using Application.Persons.Commands.DeletePerson;
using Application.Persons.Commands.EditPerson;
using Application.Persons.Queries.GetPerson;
using Application.Persons.Queries.GetPersons;
using Infrastructure.Api.Contracts;
using Infrastructure.Api.Contracts.Person;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api.Controllers;

[Route("api/[controller]")]
public class PersonController(ISender sender) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonRequest request)
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

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeletePersonCommand(id);

        var result = await sender.Send(command);

        return result.Match(
            _ => NoContent(),
            _ => Problem(result.Errors));
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] EditPersonRequest request)
    {
        var command = new EditPersonCommand(id, request.FirstName, request.LastName, request.MiddleName,
            request.Birthday, request.Gender, request.PhoneNumber, request.Telegram);

        var result = await sender.Send(command);

        return result.Match(
            _ => Ok(result.Value),
            _ => Problem(result.Errors));
    }

    [HttpPost("{id:guid}/customFields")]
    public async Task<IActionResult> AddCustomField(Guid id, [FromBody] AddCustomFieldRequest request)
    {
        var command = new AddCustomFieldCommand(id, request.Name, request.Value);

        var result = await sender.Send(command);

        return result.Match(
            _ => Ok(),
            _ => Problem(result.Errors));
    }
}