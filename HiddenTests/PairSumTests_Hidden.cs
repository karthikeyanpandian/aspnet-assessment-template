using Xunit;
using AspNetAlgorithmicAssessment.Controllers;
using AspNetAlgorithmicAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;

public class PairSumTests_Hidden
{
    [Fact]
    public void PairSum_DuplicateValues()
    {
        var controller = new PairSumController();
        var req = new PairSumRequest { Numbers = new int[]{3,3,3,3}, Target = 6};
        var res = controller.CountPairs(req) as OkObjectResult;
        var json = JObject.FromObject(res.Value);
        // unique unordered pairs by value: (3,3) counted once
        Assert.Equal(1, (int)json["count"]);
    }

    [Fact]
    public void PairSum_PerformanceLarge()
    {
        var rand = new Random(42);
        var arr = new int[10000];
        for (int i=0;i<arr.Length;i++) arr[i] = rand.Next(0,5000);
        var controller = new PairSumController();
        var req = new PairSumRequest { Numbers = arr, Target = 2500 };
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var res = controller.CountPairs(req) as OkObjectResult;
        watch.Stop();
        Assert.True(watch.Elapsed.TotalSeconds < 2.5);
    }
}
