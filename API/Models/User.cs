namespace API.Models;

public class User
{
    public string sessionId { get; set; } = string.Empty;

    public DateTime startedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime endsAt { get { return this.startedAt.AddSeconds(this.durationSec); } }

    public long durationSec { get; set; } = 0;
}