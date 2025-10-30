using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class SessionController : Controller
{
    [HttpPost("start")]
    public IActionResult Start([FromBody] User request)
    {
        if (request == null || request.durationSec <= 0 || request.durationSec > long.MaxValue)
            return BadRequest(new { error = "Invalid durationSec" });

        if (request.sessionId == null || request.sessionId == string.Empty)
            request.sessionId = Guid.NewGuid().ToString();

        request.startedAt = DateTime.UtcNow;

        Session.users.Add(request);

        return Ok(request);
    }

    [HttpGet("/{sessionId}")]
    public IActionResult Start(string sessionId)
    {
        Session.users.RemoveAll(x => x.endsAt <= DateTime.UtcNow);

        User? user = Session.users.Where(x => x.sessionId == sessionId).FirstOrDefault();

        if (user != null)
            return Ok(user);

        return NotFound();

    }
}
