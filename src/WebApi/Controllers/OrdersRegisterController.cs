using Application;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace WebApi.Controllers;


[ApiController]
[Route("RegPoz")]
[SwaggerTag("Gets, Creates, Appends and Deletes Orders Register objects")]

public class OrdersRegisterController : ControllerBase
{
    private readonly OrdersRegisterService _service;
    public OrdersRegisterController(OrdersRegisterService service)
    {
        _service = service;
    }

    [HttpGet()]
    [Consumes(MediaTypeNames.Application.Json)]
    [SwaggerOperation(Summary = "Shows order register entry of given id",
                Description = "Shows order registration data according given id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully returned order rigister entry", typeof(OrdersRegisterEntity), MediaTypeNames.Application.Json)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById([FromQuery] int regid)
    {
        ResponseEntry response = _service.GetById(regid);
        return Ok(response);
    }

    [HttpGet("All")]
    public IActionResult GetAll()
    {
        ResponseEntries response = _service.GetAll();
        return Ok(response);
    }

    [HttpPost()]
    public IActionResult Create([FromBody] RequestCreate createDto)
    {
        ResponseEntry response = _service.Create(createDto);
        return Created("get", response);
    }

    [HttpPut()]
    public IActionResult Update([FromBody] RequestUpdate updateDto)
    {
        ResponseEntry response = _service.Update(updateDto);
        return Created("get", response);
    }

    [HttpDelete()]
    public IActionResult delete([FromQuery] int regid)
    {
        _service.Delete(regid);
        return NoContent();
    }
}

