namespace AspNetAlgorithmicAssessment.Services;
public interface INotificationService
{
    // Returns true if the notification was allowed and 'sent', false if rate limited
    bool TrySend(string? userId);
}
