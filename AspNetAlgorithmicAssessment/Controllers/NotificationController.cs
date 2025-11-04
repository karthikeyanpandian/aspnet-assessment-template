using Microsoft.AspNetCore.Mvc;
using AspNetAlgorithmicAssessment.Services;

namespace AspNetAlgorithmicAssessment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _service;
    public NotificationController(INotificationService service)
    {
        _service = service;
    }

    // POST api/notification/send
    // Request: { "userId": "user1" }
    // Response: { "sent": true } or { "sent": false, "reason": "rate_limited" }
    // Requirements: implement sending that allows max 5 sends per user in a sliding window of 1 minute.
    [HttpPost("send")]
    public IActionResult SendNotification([FromBody] AspNetAlgorithmicAssessment.Models.NotificationRequest req)
    {
        var ok = _service.TrySend(req?.UserId);
        if (ok) return Ok(new { sent = true });
        return Ok(new { sent = false, reason = "rate_limited" });
    }
}
