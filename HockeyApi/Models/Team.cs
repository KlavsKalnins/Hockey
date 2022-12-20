using System.Text.Json.Serialization;

namespace HockeyApi.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonIgnore]
    public List<Player> Players { get; set; }
    // Event object
}
