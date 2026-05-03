using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API1._0.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}