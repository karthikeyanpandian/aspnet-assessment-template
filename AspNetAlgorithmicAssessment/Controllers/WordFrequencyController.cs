using Microsoft.AspNetCore.Mvc;
using AspNetAlgorithmicAssessment.Models;

namespace AspNetAlgorithmicAssessment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordFrequencyController : ControllerBase
{
    // POST api/wordfrequency/word-frequency
    // Request: { "sentence": "the quick brown fox the quick" }
    // Response: { "frequencies": [ { "word": "the", "count": 2 }, ... ] }
    // Requirements: case-insensitive, ignore punctuation, sort by count desc then word asc
    [HttpPost]
    [Route("word-frequency")]
    public IActionResult GetWordFrequency([FromBody] WordFrequencyRequest req)
    {
        // TODO: Implement word frequency logic
        return Ok(new { frequencies = new object[0] });
    }
}
