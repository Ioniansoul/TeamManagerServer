using Microsoft.EntityFrameworkCore;
public class TeamManagerContext : DbContext
{
    public TeamManagerContext(DbContextOptions<TeamManagerContext> options) : base(options)
    {
        // Constructor logic, if needed
    }

    // DbSet properties for your entities
    public DbSet<Player> Players { get; set; }
    // Other DbSet properties for your entities
}

