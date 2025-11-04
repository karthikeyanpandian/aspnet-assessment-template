using Xunit;
using AspNetAlgorithmicAssessment.Controllers;
using AspNetAlgorithmicAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

public class WordFrequencyTests_Visible
{
    [Fact]
    public void WordFreq_Basic()
    {
        var controller = new WordFrequencyController();
        var req = new WordFrequencyRequest { Sentence = "The quick brown fox the quick" };
        var result = controller.GetWordFrequency(req) as OkObjectResult;
        Assert.NotNull(result);
        var json = JObject.FromObject(result.Value);
        var freqs = json["frequencies"].ToObject<System.Collections.Generic.List<JObject>>();
        Assert.Equal("the", (string)freqs[0]["word"]);
        Assert.Equal(2, (int)freqs[0]["count"]);
    }

    [Fact]
    public void WordFreq_Punctuation()
    {
        var controller = new WordFrequencyController();
        var req = new WordFrequencyRequest { Sentence = "Hello, world! Hello" };
        var result = controller.GetWordFrequency(req) as OkObjectResult;
        var json = JObject.FromObject(result.Value);
        var freqs = json["frequencies"].ToObject<System.Collections.Generic.List<JObject>>();
        Assert.Equal("hello", (string)freqs[0]["word"]);
        Assert.Equal(2, (int)freqs[0]["count"]);
    }
}
