using HockeyApi.Models;
using HockeyApi.Services;
using HockeyApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HockeyApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet(Name = "GetPlayers")]
        public async Task<IEnumerable<Player>> Get()
        {
            var players = await _playerService.GetPlayersAsync();
            return players;
        }

        [HttpGet(Name = "GetPlayersWithTeams")]
        public async Task<IEnumerable<Player>> GetPlayersWithTeams()
        {
            var players = await _playerService.GetPlayersAsync();
            return players;
            //var players = await _playerService.GetPlayersWithTeamsAsync();
            //return players;
        }
        [HttpPost(Name = "AddPlayer")]
        public async Task<Player> Post(string playerName)
        {
            var newPlayer = new Player();
            newPlayer.Name = playerName;
            var player = await _playerService.AddPlayerAsync(newPlayer);
            return player;
        }
    }
}
