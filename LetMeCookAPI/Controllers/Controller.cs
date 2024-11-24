using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class GeneralController : ControllerBase
{
    [HttpGet("healthcheck")]
    public IActionResult HealthCheck()
    {
        return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
    }
}