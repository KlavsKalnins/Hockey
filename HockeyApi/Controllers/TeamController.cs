using HockeyApi.Models;
using HockeyApi.Models.Relationship;
using HockeyApi.Services;
using HockeyApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HockeyApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet(Name = "GetTeams")]
        public async Task<IEnumerable<Team>> Get()
        {
            var teams = await _teamService.GetTeamsAsync();
            return teams;
        }
        [HttpPost(Name = "AddTeam")]
        public async Task<Team> AddTeam(string teamName)
        {
            var newTeam = new Team {
                Name = teamName, 
            };
            await _teamService.AddTeam(newTeam);
            return newTeam;
        }

        [HttpPost(Name = "AddTeamPlayer")]
        public async Task<Team> AddTeamPlayer(TeamPlayer teamPlayer)
        {
            var team = await _teamService.AddTeamPlayerAsync(teamPlayer);
            return team;
        }
    }
}
