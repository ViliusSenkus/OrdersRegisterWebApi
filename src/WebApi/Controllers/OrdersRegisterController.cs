using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("RegPoz")]

public class OrdersRegisterController : ControllerBase
{
    [HttpGet("regid={id}")]
    public IEnumerable<OrdersRegisterEntity> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new OrdersRegisterEntity
        {
            //Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //TemperatureC = Random.Shared.Next(-20, 55),
            //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

