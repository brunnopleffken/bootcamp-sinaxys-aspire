using Microsoft.AspNetCore.Mvc;

namespace Katalog.ApiService.Features.Data;

[ApiController]
[Route("/")]
public class DataController : ControllerBase
{
    [HttpGet]
    public IActionResult Check()
    {
        return Ok(new { Online = true });
    }
}
