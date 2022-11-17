using System.Net;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ConsumoController : ControllerBase
{
    [HttpGet]
   public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
}