using Xunit;
using AspNetAlgorithmicAssessment.Services;

public class NotificationTests_Visible
{
    [Fact]
    public void Notification_AllowsUpToFive()
    {
        var svc = new InMemoryNotificationService();
        var user = "u1";
        for (int i = 0; i < 5; i++) Assert.True(svc.TrySend(user));
        Assert.False(svc.TrySend(user)); // 6th should be rate limited in same window
    }
}
