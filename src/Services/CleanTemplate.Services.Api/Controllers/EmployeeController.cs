using System.Net;
using System.Net.Mime;
using CleanTemplate.Application.Core;
using CleanTemplate.Transversal.Core;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CleanTemplate.Services.Api;

public class EmployeeController : BaseAppController
{
    private IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "Create Employee")]    
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<EmployeeResponseDto>>> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        var result = await _mediator.Send(command);

        return Created(new Uri(Request.GetEncodedUrl()), result);
    }

    [HttpDelete(Name = "Delete Employee")]    
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<AreaResponseDto>>> DeleteEmployee(int id)
    {
        var request = new DeleteEmployeeCommand() 
        {
            Id = id
        };
        
        var result = await _mediator.Send(request);

        return Ok(result);

    }     

    [HttpPut(Name = "Update Employee")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<EmployeeUpdateResponseDto>>> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet(Name = "Get all employees")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<EmployeeListDto>>> GetAll()
    {
        var employeeListQuery = new GetEmployeeListQuery();
        var result = await _mediator.Send(employeeListQuery);

        return Ok(result);
    }

    [HttpGet(Name = "Get by id Employee")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<EmployeeResponseItemDto>>> GetById(int id)
    {
        var areaComandItem = new GetItemEmployeeQuery() {
            Id = id
        };

        var result = await _mediator.Send(areaComandItem);

        return Ok(result);
    }           

}
