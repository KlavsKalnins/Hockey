using HockeyApi.Models;

namespace HockeyApi.Services.Interfaces;

public interface IPlayerService
{
    Task<List<Player>> GetPlayersAsync();
    Task<List<Player>> GetPlayersWithTeamsAsync();
    Task<Player> AddPlayerAsync(Player player);
}
