using HockeyApi.Models;
using HockeyApi.Models.Relationship;

namespace HockeyApi.Services.Interfaces;

public interface ITeamService
{
    Task<List<Team>> GetTeamsAsync();
    Task<Team> AddTeam(Team team);
    Task<Team> AddTeamPlayerAsync(TeamPlayer teamPlayer);
}
