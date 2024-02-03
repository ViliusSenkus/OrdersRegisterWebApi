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
    [HttpGet(Name = "GetWeatherForecast"))]
    [Consumes(MediaTypeNames.Application.Json)]
    [SwaggerOperation(Summary = "Shows order register entry of given id",
                Description = "Shows order registration data according given id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully returned order rigister entry", typeof(OrdersRegisterEntity), MediaTypeNames.Application.Json)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById([FromQuery] int regid)
    {
        string response = "iskomas irasas - Nr." + regid;
        return Ok(response);
    }

    [HttpGet()]
    public IActionResult GetAll()
    {
        string response = "Cia visas sarasas irasu ";
        return Ok(response);
    }

    [HttpPost()]
    public IActionResult Create([FromBody] OrdersRegisterEntity changedEntity)
    {
        string response = changedEntity.CountingMethod;
        return Created("get", response);
    }

    [HttpPut()]
    public IActionResult Update([FromQuery] int regid, [FromBody] OrdersRegisterEntity changedEntity)
    {
        string response = changedEntity.CountingMethod;
        return Created("get", response);
    }

    [HttpDelete()]
    public IActionResult delete([FromQuery] int regid)
    {
        string response = "iskomas irasas - Nr." + regid;
        return NoContent();
    }
}

