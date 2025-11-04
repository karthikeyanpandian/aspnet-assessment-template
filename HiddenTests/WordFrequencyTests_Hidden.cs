using Xunit;
using AspNetAlgorithmicAssessment.Controllers;
using AspNetAlgorithmicAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

public class WordFrequencyTests_Hidden
{
    [Fact]
    public void WordFreq_CaseAndPunctuations()
    {
        var controller = new WordFrequencyController();
        var req = new WordFrequencyRequest { Sentence = "Apple! apple, APPLE? banana; BANANA" };
        var result = controller.GetWordFrequency(req) as OkObjectResult;
        var json = JObject.FromObject(result.Value);
        var freqs = json["frequencies"].ToObject<System.Collections.Generic.List<JObject>>();
        Assert.Equal("apple", (string)freqs[0]["word"]);
        Assert.Equal(3, (int)freqs[0]["count"]);
        Assert.Equal("banana", (string)freqs[1]["word"]);
        Assert.Equal(2, (int)freqs[1]["count"]);
    }
}
