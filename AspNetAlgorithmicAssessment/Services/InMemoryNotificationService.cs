using System.Collections.Concurrent;

namespace AspNetAlgorithmicAssessment.Services;

// Starter implementation: fixed-window per-user counter for 60 seconds.
// Candidates can improve to sliding-window for hidden tests.
public class InMemoryNotificationService : INotificationService
{
    private readonly ConcurrentDictionary<string, (int Count, long WindowStartTicks)> _store = new();

    public bool TrySend(string? userId)
    {
        if (string.IsNullOrEmpty(userId)) return false;
        var key = userId!;
        var now = DateTime.UtcNow.Ticks;
        var entry = _store.GetOrAdd(key, (_)=> (0, now));
        var windowStart = entry.WindowStartTicks;
        var elapsed = TimeSpan.FromTicks(now - windowStart).TotalSeconds;
        if (elapsed >= 60)
        {
            _store[key] = (1, now);
            return true;
        }
        else
        {
            if (entry.Count >= 5) return false;
            _store[key] = (entry.Count + 1, windowStart);
            return true;
        }
    }
}
