using HockeyApi.Data;
using HockeyApi.Models;
using HockeyApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HockeyApi.Services
{
    public class PlayerService : IPlayerService
    {
        protected readonly AppDbContext _context;

        public PlayerService(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }

        public async Task<Player> AddPlayerAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            return await _context.Players
                .ToListAsync();
        }
        public async Task<List<Player>> GetPlayersWithTeamsAsync()
        {
            return await _context.Players
                .Include(c => c.Teams)
                .ToListAsync();
        }
    }
}
