using HockeyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HockeyApi.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Player> Players => Set<Player>();
    public DbSet<Team> Teams => Set<Team>();

}
