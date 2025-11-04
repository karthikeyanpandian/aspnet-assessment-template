using Xunit;
using AspNetAlgorithmicAssessment.Controllers;
using AspNetAlgorithmicAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

public class PairSumTests_Visible
{
    [Fact]
    public void PairSum_Basic()
    {
        var controller = new PairSumController();
        var req = new PairSumRequest { Numbers = new int[]{1,2,3,4,3}, Target = 6};
        var result = controller.CountPairs(req) as OkObjectResult;
        Assert.NotNull(result);
        var json = JObject.FromObject(result.Value);
        Assert.Equal(2, (int)json["count"]);
    }

    [Fact]
    public void PairSum_NoPairs()
    {
        var controller = new PairSumController();
        var req = new PairSumRequest { Numbers = new int[]{1,1,1}, Target = 10};
        var result = controller.CountPairs(req) as OkObjectResult;
        var json = JObject.FromObject(result.Value);
        Assert.Equal(0, (int)json["count"]);
    }
}
