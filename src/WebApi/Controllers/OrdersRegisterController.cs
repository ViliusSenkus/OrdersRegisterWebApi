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
    [HttpGet()]
    [Consumes(MediaTypeNames.Application.Json)]
    [SwaggerOperation(Summary = "Shows order register entry of given id",
                Description = "Shows order registration data according given id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully returned order rigister entry", typeof(OrdersRegisterEntity), MediaTypeNames.Application.Json)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public IActionResult Get([FromQuery] int regid)
    {
        string response = "iskomas irasas - Nr." + regid;
        return Ok(response);
            
        //    Enumerable.Range(1, 5).Select(index => new OrdersRegisterEntity
        //{
            //Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //TemperatureC = Random.Shared.Next(-20, 55),
            //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //})
        //.ToArray();
    }
}

