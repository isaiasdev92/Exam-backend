using System.Net;
using System.Net.Mime;
using CleanTemplate.Application.Core;
using CleanTemplate.Transversal.Core;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CleanTemplate.Services.Api;

public class AreaController : BaseAppController
{
    private IMediator _mediator;

    public AreaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "Create Area")]    
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<AreaResponseDto>>> CreateArea([FromBody] CreateAreaCommand command)
    {
        var result = await _mediator.Send(command);

        return Created(new Uri(Request.GetEncodedUrl()), result);
    }

    [HttpDelete(Name = "Delete Area")]    
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<AreaResponseDto>>> DeleteArea(int id)
    {
        var request = new DeleteAreaCommand() 
        {
            Id = id
        };
        var result = await _mediator.Send(request);

        return Ok(result);

    } 

    [HttpPut(Name = "Update Area")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<AreaUpdateResponseDto>>> UpdateArea([FromBody] UpdateAreaCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }       

    [HttpGet(Name = "Get all areas")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<AreaListDto>>> GetAll()
    {
        var areaComandlist = new GetAreasListQuery();
        var result = await _mediator.Send(areaComandlist);

        return Ok(result);
    } 

    [HttpGet(Name = "Get by id Area")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<Response<AreaItemDto>>> GetById(int id)
    {
        var areaComandItem = new GetItemAreaQuery() {
            Id = id
        };

        var result = await _mediator.Send(areaComandItem);

        return Ok(result);
    }                
}
