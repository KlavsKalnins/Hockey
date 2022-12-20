using HockeyApi.Data;
using HockeyApi.Models;
using HockeyApi.Models.Relationship;
using HockeyApi.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HockeyApi.Services
{
    public class TeamService : ITeamService
    {
        protected readonly AppDbContext _context;

        public TeamService(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }
        public async Task<List<Team>> GetTeamsAsync()
        {
            var teams = await _context.Teams.Include(t => t.Players).ToListAsync();
            return teams;
        }
        public async Task<Team> AddTeam(Team team)
        {
            _context.Teams.Add(team);
            // check if team name exists
            await _context.SaveChangesAsync();
            return team;
        }
        public async Task<Team> AddTeamPlayerAsync(TeamPlayer teamPlayer)
        {

            var player = await _context.Players.Where(c => c.Id == teamPlayer.PlayerId).Include(c => c.Teams).FirstOrDefaultAsync();

            if (player == null)
            {
                return null;
            }

            var team = await _context.Teams.FindAsync(teamPlayer.TeamId);

            if (team == null)
            {
                return null;
            }
            player.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }
    }
}
