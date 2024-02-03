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
    public async Task<IActionResult> GetById([FromQuery] int regid)
    {
        ResponseEntry response = await _service.GetById(regid);
        return Ok(response);
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAll()
    {
        ResponseEntries response = await _service.GetAll();
        return Ok(response);
    }

    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] RequestCreate createDto)
    {
        ResponseEntry response = await _service.Create(createDto);
        return Created("get", response);
    }

    [HttpPut()]
    public async Task<IActionResult> Update([FromBody] RequestUpdate updateDto)
    {
        ResponseEntry response = await _service.Update(updateDto);
        return Created("get", response);
    }

    [HttpDelete()]
    public async Task<IActionResult> Delete([FromQuery] int regid)
    {
        await _service.Delete(regid);
        return NoContent();
    }
}

