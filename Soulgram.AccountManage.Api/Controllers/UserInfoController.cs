using Microsoft.AspNetCore.Mvc;

namespace Soulgram.AccountManage.Api.Controllers;

[Route("api/[controller]")]
public class UserInfoController : ControllerBase
{
    [HttpGet("healthcheck")]
    public IActionResult HealthCheck()
    {
        return Ok();
    }
}