using System.Text.Json.Serialization;

namespace HockeyApi.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    //[JsonIgnore]
    public List<Team> Teams { get; set; } // public ICollection<Team> Teams { get; set; }
}
