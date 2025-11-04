using Xunit;
using AspNetAlgorithmicAssessment.Services;
using System.Threading.Tasks;

public class NotificationTests_Hidden
{
    [Fact]
    public void Notification_SlidingWindowBehavior()
    {
        var svc = new InMemoryNotificationService();
        string user = "testuser";
        for (int i=0;i<5;i++) Assert.True(svc.TrySend(user));
        Assert.False(svc.TrySend(user));
        // Hidden tests may simulate time advancement externally if needed.
    }
}
