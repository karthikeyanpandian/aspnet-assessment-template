using Microsoft.AspNetCore.Mvc;
using AspNetAlgorithmicAssessment.Models;

namespace AspNetAlgorithmicAssessment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PairSumController : ControllerBase
{
    // POST api/pairs/count
    // Request: { "numbers": [1,2,3,4,3], "target": 6 }
    // Response: { "count": 2 } // pairs: (2,4) and (3,3) counted once each
    [HttpPost("count")]
    public IActionResult CountPairs([FromBody] PairSumRequest req)
    {
        // TODO: Implement efficient counting of unique unordered pairs that sum to target.
        // Requirements: O(n) or O(n log n) expected, handle duplicates correctly, positive/negative numbers allowed.
        return Ok(new { count = 0 });
    }
}
